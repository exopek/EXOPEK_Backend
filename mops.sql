CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Workouts" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Description" text NULL,
    CONSTRAINT "PK_Workouts" PRIMARY KEY ("Id")
);

CREATE TABLE "Image" (
    "Id" uuid NOT NULL,
    "WorkoutId" uuid NULL,
    CONSTRAINT "PK_Image" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Image_Workouts_WorkoutId" FOREIGN KEY ("WorkoutId") REFERENCES "Workouts" ("Id")
);

CREATE TABLE "Video" (
    "Id" uuid NOT NULL,
    "WorkoutId" uuid NULL,
    CONSTRAINT "PK_Video" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Video_Workouts_WorkoutId" FOREIGN KEY ("WorkoutId") REFERENCES "Workouts" ("Id")
);

CREATE INDEX "IX_Image_WorkoutId" ON "Image" ("WorkoutId");

CREATE INDEX "IX_Video_WorkoutId" ON "Video" ("WorkoutId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230726045105_2023-07-26-js', '7.0.9');

COMMIT;

START TRANSACTION;

ALTER TABLE "Image" DROP CONSTRAINT "FK_Image_Workouts_WorkoutId";

UPDATE "Image" SET "WorkoutId" = '00000000-0000-0000-0000-000000000000' WHERE "WorkoutId" IS NULL;
ALTER TABLE "Image" ALTER COLUMN "WorkoutId" SET NOT NULL;
ALTER TABLE "Image" ALTER COLUMN "WorkoutId" SET DEFAULT '00000000-0000-0000-0000-000000000000';

ALTER TABLE "Image" ADD CONSTRAINT "FK_Image_Workouts_WorkoutId" FOREIGN KEY ("WorkoutId") REFERENCES "Workouts" ("Id") ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230804074629_2023-08-04-js', '7.0.9');

COMMIT;

START TRANSACTION;

ALTER TABLE "Image" DROP CONSTRAINT "FK_Image_Workouts_WorkoutId";

ALTER TABLE "Image" ALTER COLUMN "WorkoutId" DROP NOT NULL;

ALTER TABLE "Image" ADD CONSTRAINT "FK_Image_Workouts_WorkoutId" FOREIGN KEY ("WorkoutId") REFERENCES "Workouts" ("Id");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230804080402_2023-08-04-js-1', '7.0.9');

COMMIT;

