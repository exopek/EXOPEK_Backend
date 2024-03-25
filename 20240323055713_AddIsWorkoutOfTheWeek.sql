START TRANSACTION;

DELETE FROM "AspNetRoles"
WHERE "Id" = '0d7f67e9-90ee-40cc-9dce-89bd0cf06a95';

DELETE FROM "AspNetRoles"
WHERE "Id" = '41c9c3b1-e49e-4b66-b562-fa61cf5a6a16';

ALTER TABLE "Workouts" ADD "IsWorkoutOfTheWeek" boolean NOT NULL DEFAULT FALSE;

INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('216919dd-3a81-4c24-ae7b-f15cc9b2dd6c', NULL, 'User', 'USER');
INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('88288dd1-b0a3-497b-b258-988fc5d064ea', NULL, 'Administrator', 'ADMINISTRATOR');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240323055713_AddIsWorkoutOfTheWeek', '7.0.9');

COMMIT;

