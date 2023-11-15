START TRANSACTION;

DELETE FROM "AspNetRoles"
WHERE "Id" = '5f229b72-05a3-4571-8242-5bffbe20ff58';

DELETE FROM "AspNetRoles"
WHERE "Id" = 'a1ab4215-3553-4b63-b8c8-9e31fc9c3739';

ALTER TABLE "PlanUserStatus" ADD "CreatedAt" timestamp with time zone NOT NULL DEFAULT TIMESTAMPTZ '-infinity';

ALTER TABLE "PlanUserStatus" ADD "Status" integer NOT NULL DEFAULT 0;

ALTER TABLE "Plans" ADD "PhaseNames" text NOT NULL DEFAULT '';

INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('57e4aca9-6087-4c73-b322-bee70fdf4d61', '7a2d9d9c-5974-4cb8-a11e-99d9b3e25747', 'User', 'USER');
INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('8ac1b9ba-1dc3-43af-8a68-1d4eebb3c80a', '795747c1-d4e7-4ab7-88ec-40cf7fba9736', 'Administrator', 'ADMINISTRATOR');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231026043344_2023-10-26-js', '7.0.9');

COMMIT;

