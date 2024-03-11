START TRANSACTION;

DELETE FROM "AspNetRoles"
WHERE "Id" = '9db5f8c9-71a1-45ed-8ead-9d47e72fb685';

DELETE FROM "AspNetRoles"
WHERE "Id" = 'c048b41e-3b86-4b07-9f04-bc9f0e8d7308';

ALTER TABLE "AspNetUsers" ALTER COLUMN "ImageUrl" DROP NOT NULL;

ALTER TABLE "AspNetUsers" ADD "Age" integer NULL;

ALTER TABLE "AspNetUsers" ADD "Height" double precision NULL;

ALTER TABLE "AspNetUsers" ADD "PreviousTrainingFrequency" integer NULL;

ALTER TABLE "AspNetUsers" ADD "SportType" integer NULL;

ALTER TABLE "AspNetUsers" ADD "TrainingFrequency" integer NULL;

ALTER TABLE "AspNetUsers" ADD "Weight" double precision NULL;

INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('537da145-63ca-4758-a4d0-05ae61937fee', NULL, 'Administrator', 'ADMINISTRATOR');
INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('6d3c9580-acde-4bc5-9ff8-d4f20a222242', NULL, 'User', 'USER');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240308050130_AddUserProperties', '7.0.9');

COMMIT;

