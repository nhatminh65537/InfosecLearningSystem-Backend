using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfosecLearningSystem_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateViewAndTrigger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create user_permissions_view
            migrationBuilder.Sql(@"
                CREATE MATERIALIZED VIEW user_permissions_view AS
                SELECT
                    ur.user_id AS user_id,
                    rp.permission_name AS permission_name
                FROM user_roles ur
                JOIN role_permissions rp ON ur.role_name = rp.role_name
                UNION
                SELECT
                    up.user_id AS user_id,
                    up.permission_name AS permission_name
                FROM user_permissions up;
                ");

            migrationBuilder.Sql(@"
                CREATE INDEX ix_user_permission_id ON user_permissions_view (user_id, permission_name);
                ");

            // Trigger to refresh user_permissions_view
            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION refresh_user_permissions_view() RETURNS TRIGGER AS $$
                BEGIN
                    REFRESH MATERIALIZED VIEW user_permissions_view;
                    RETURN NULL;
                END;
                $$ LANGUAGE plpgsql;
                ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER refresh_user_permissions_view_trigger
                AFTER INSERT OR UPDATE OR DELETE ON user_roles
                FOR EACH STATEMENT
                EXECUTE FUNCTION refresh_user_permissions_view();
                ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER refresh_user_permissions_view_trigger
                AFTER INSERT OR UPDATE OR DELETE ON role_permissions
                FOR EACH STATEMENT
                EXECUTE FUNCTION refresh_user_permissions_view();
                ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER refresh_user_permissions_view_trigger
                AFTER INSERT OR UPDATE OR DELETE ON user_permissions
                FOR EACH STATEMENT
                EXECUTE FUNCTION refresh_user_permissions_view();
                ");

            // Trigger to create user profile
            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION create_user_profile()
                RETURNS TRIGGER AS $$
                BEGIN
                    INSERT INTO user_profiles (user_id, display_name)
                    VALUES (NEW.id, NEW.user_name);
                    RETURN NEW;
                END;
                $$ LANGUAGE plpgsql;

                CREATE TRIGGER create_user_profile_trigger
                AFTER INSERT ON users
                FOR EACH ROW
                EXECUTE FUNCTION create_user_profile();
            ");

            // Trigger to update modules when lessons are updated
            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION update_module_on_lesson_change()
                RETURNS TRIGGER AS $$
                BEGIN
                    UPDATE modules
                    SET xp = (SELECT SUM(xp) FROM lessons WHERE module_id = NEW.module_id),
                        duration = (SELECT SUM(duration) FROM lessons WHERE module_id = NEW.module_id),
                        updated_at = NOW()
                    WHERE id = NEW.module_id;
                    RETURN NEW;
                END;
                $$ LANGUAGE plpgsql;

                CREATE TRIGGER update_module_on_lesson_change_trigger
                AFTER INSERT OR UPDATE OR DELETE ON lessons
                FOR EACH ROW
                EXECUTE FUNCTION update_module_on_lesson_change();
            ");

            // Trigger to update modules when content items are updated
            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION update_module_on_content_item_change()
                RETURNS TRIGGER AS $$
                BEGIN
                    UPDATE modules
                    SET updated_at = NOW()
                    WHERE id = NEW.module_id;
                    RETURN NEW;
                END;
                $$ LANGUAGE plpgsql;

                CREATE TRIGGER update_module_on_content_item_change_trigger
                AFTER INSERT OR UPDATE OR DELETE ON content_items
                FOR EACH ROW
                EXECUTE FUNCTION update_module_on_content_item_change();
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP TRIGGER IF EXISTS refresh_user_permissions_view_trigger ON user_roles;
                DROP TRIGGER IF EXISTS refresh_user_permissions_view_trigger ON role_permissions;
                DROP TRIGGER IF EXISTS refresh_user_permissions_view_trigger ON user_permissions;
                DROP FUNCTION IF EXISTS refresh_user_permissions_view;
                DROP MATERIALIZED VIEW IF EXISTS user_permissions_view;
                ");
            migrationBuilder.Sql(@"
                DROP TRIGGER IF EXISTS create_user_profile_trigger ON users;
                DROP FUNCTION IF EXISTS create_user_profile();
            ");
            migrationBuilder.Sql(@"
                DROP TRIGGER IF EXISTS update_module_on_lesson_change_trigger ON lessons;
                DROP FUNCTION IF EXISTS update_module_on_lesson_change;
            ");

            migrationBuilder.Sql(@"
                DROP TRIGGER IF EXISTS update_module_on_content_item_change_trigger ON content_items;
                DROP FUNCTION IF EXISTS update_module_on_content_item_change;
            ");
        }
    }
}
