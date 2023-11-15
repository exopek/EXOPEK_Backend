START TRANSACTION;

DELETE FROM "AspNetRoles"
WHERE "Id" = '57e4aca9-6087-4c73-b322-bee70fdf4d61';

DELETE FROM "AspNetRoles"
WHERE "Id" = '8ac1b9ba-1dc3-43af-8a68-1d4eebb3c80a';

ALTER TABLE "AspNetUsers" ADD "ImageUrl" text NOT NULL DEFAULT '';

INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('24262287-86aa-41d0-ab54-ce32a1ffadc9', '5de61442-abed-464e-ad4f-ec83683f5204', 'User', 'USER');
INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('61ec44ee-7add-4ad1-82e7-fc4d3e67197a', '77b1b54e-6505-41af-ae08-4353de9bac5d', 'Administrator', 'ADMINISTRATOR');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231115173459_2023-11-15-js', '7.0.9');

COMMIT;

