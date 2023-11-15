START TRANSACTION;

DELETE FROM "AspNetRoles"
WHERE "Id" = '424f26d9-c65a-462f-a2ca-4eaf9d69e415';

DELETE FROM "AspNetRoles"
WHERE "Id" = 'b0972fb5-37b9-45e7-8fa6-8bbc17f2db71';

ALTER TABLE "PlanWorkout" ADD "IsCompleted" boolean NOT NULL DEFAULT FALSE;

ALTER TABLE "PlanWorkout" ADD "Order" integer NOT NULL DEFAULT 0;

INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('09432400-db8d-4923-9cda-47f5f2cdfd93', 'e38bfbb1-5b56-43c6-bb1d-7d3dcec44ddf', 'Administrator', 'ADMINISTRATOR');
INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('3a870a30-f3d5-44f9-9e7a-68d2a9a12847', '1d218900-ff90-4f0e-8b5b-87757372b240', 'User', 'USER');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231022065549_2023-10-22-js', '7.0.9');

COMMIT;

