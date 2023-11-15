START TRANSACTION;

DELETE FROM "AspNetRoles"
WHERE "Id" = '09432400-db8d-4923-9cda-47f5f2cdfd93';

DELETE FROM "AspNetRoles"
WHERE "Id" = '3a870a30-f3d5-44f9-9e7a-68d2a9a12847';

ALTER TABLE "PlanWorkout" DROP COLUMN "IsCompleted";

ALTER TABLE "PlanUserStatus" ADD "WorkoutIds" text NOT NULL DEFAULT '';

INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('5f229b72-05a3-4571-8242-5bffbe20ff58', '31f429f1-ac60-4e6d-83a3-f539bc87feff', 'Administrator', 'ADMINISTRATOR');
INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('a1ab4215-3553-4b63-b8c8-9e31fc9c3739', '2d010015-0cca-4307-991d-e35abc76fc8a', 'User', 'USER');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231023044906_2023-10-23-js', '7.0.9');

COMMIT;

