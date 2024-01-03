START TRANSACTION;

DELETE FROM "AspNetRoles"
WHERE "Id" = '24262287-86aa-41d0-ab54-ce32a1ffadc9';

DELETE FROM "AspNetRoles"
WHERE "Id" = '61ec44ee-7add-4ad1-82e7-fc4d3e67197a';

ALTER TABLE "PlanUserStatus" ADD "ProgressPercentage" integer NOT NULL DEFAULT 0;

INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('a0414525-426f-4a09-a0db-b7ee4c521710', '621a90c7-749d-4bcb-9e3f-6caf277c3735', 'User', 'USER');
INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('a070bb90-b213-4f78-98a1-d0c047636ea9', 'b22d29fa-b590-4a84-ba01-d0df1b5c493b', 'Administrator', 'ADMINISTRATOR');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240103101809_AddProgressPercentageToPlanStatus', '7.0.9');

COMMIT;

