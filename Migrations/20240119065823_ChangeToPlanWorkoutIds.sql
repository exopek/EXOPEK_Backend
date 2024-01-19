START TRANSACTION;

DELETE FROM "AspNetRoles"
WHERE "Id" = 'a0414525-426f-4a09-a0db-b7ee4c521710';

DELETE FROM "AspNetRoles"
WHERE "Id" = 'a070bb90-b213-4f78-98a1-d0c047636ea9';

ALTER TABLE "PlanUserStatus" RENAME COLUMN "WorkoutIds" TO "PlanWorkoutIds";

INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('9db5f8c9-71a1-45ed-8ead-9d47e72fb685', 'b0984cf0-cf7c-42f6-9776-4c080873c44f', 'Administrator', 'ADMINISTRATOR');
INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('c048b41e-3b86-4b07-9f04-bc9f0e8d7308', 'a6bfdce2-52bb-4ba9-af5a-d50c1b1395ab', 'User', 'USER');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240119065823_ChangeToPlanWorkoutIds', '7.0.9');

COMMIT;

