START TRANSACTION;

DELETE FROM "AspNetRoles"
WHERE "Id" = '03cd2142-821b-4c41-8700-376df2bb2456';

DELETE FROM "AspNetRoles"
WHERE "Id" = '8336f84c-b927-4705-b1db-28dbc447f1af';

ALTER TABLE "Workouts" RENAME COLUMN "previewImage" TO "PreviewImageUrl";

ALTER TABLE "Workouts" ADD "Category" integer NOT NULL DEFAULT 0;

ALTER TABLE "Workouts" ADD "CreatedAt" timestamp with time zone NULL;

ALTER TABLE "Workouts" ADD "Difficulty" integer NOT NULL DEFAULT 0;

ALTER TABLE "Workouts" ADD "Duration" double precision NOT NULL DEFAULT 0.0;

ALTER TABLE "Workouts" ADD "Hashtags" text NOT NULL DEFAULT '';

ALTER TABLE "Workouts" ADD "MuscleImageUrl" text NULL;

ALTER TABLE "Workouts" ADD "VideoUrl" text NULL;

ALTER TABLE "WorkoutExercise" ADD "Duration" integer NULL;

ALTER TABLE "WorkoutExercise" ADD "Reps" integer NULL;

ALTER TABLE "WorkoutExercise" ADD "StageOrder" integer NOT NULL DEFAULT 0;

ALTER TABLE "WorkoutExercise" ADD "StageRound" integer NOT NULL DEFAULT 0;

ALTER TABLE "WorkoutExercise" ADD "StageType" integer NOT NULL DEFAULT 0;

ALTER TABLE "Exercise" ADD "Category" integer NOT NULL DEFAULT 0;

ALTER TABLE "Exercise" ADD "CreatedAt" timestamp with time zone NULL;

ALTER TABLE "Exercise" ADD "Difficulty" integer NOT NULL DEFAULT 0;

ALTER TABLE "Exercise" ADD "PreviewImageUrl" text NOT NULL DEFAULT '';

INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('68ba2a4b-f97a-48a8-8e5b-0b0253a5718d', 'ca04fcec-6d2a-4810-81e3-c1c5eb954dce', 'User', 'USER');
INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('b378e8f9-529f-4863-b5b1-f574f66a203d', 'bf6fe9d8-a9f1-41fa-aeb5-aeda11c8204c', 'Administrator', 'ADMINISTRATOR');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230820111618_2023-08-20-js', '7.0.9');

COMMIT;

