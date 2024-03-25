START TRANSACTION;

DELETE FROM "AspNetRoles"
WHERE "Id" = '2a99994b-1de1-43e2-b6d7-5ddbc653b062';

DELETE FROM "AspNetRoles"
WHERE "Id" = '2b0b5d4a-154a-4075-bad3-e28c1bf693dc';

ALTER TABLE "Workouts" ALTER COLUMN "Difficulty" TYPE text;
ALTER TABLE "Workouts" ALTER COLUMN "Difficulty" SET DEFAULT 'None';

ALTER TABLE "Workouts" ALTER COLUMN "Category" TYPE text;
ALTER TABLE "Workouts" ALTER COLUMN "Category" SET DEFAULT 'None';

ALTER TABLE "WorkoutExercise" ALTER COLUMN "StageType" TYPE text;
ALTER TABLE "WorkoutExercise" ALTER COLUMN "StageType" SET DEFAULT 'Main';

ALTER TABLE "WorkoutExercise" ALTER COLUMN "Reps" SET DEFAULT 0;

ALTER TABLE "PlanWorkout" ALTER COLUMN "PhaseType" TYPE text;
ALTER TABLE "PlanWorkout" ALTER COLUMN "PhaseType" SET DEFAULT 'Phase1';

ALTER TABLE "Plans" ALTER COLUMN "Target" TYPE text;
ALTER TABLE "Plans" ALTER COLUMN "Target" SET DEFAULT 'None';

ALTER TABLE "Plans" ALTER COLUMN "Difficulty" TYPE text;
ALTER TABLE "Plans" ALTER COLUMN "Difficulty" SET DEFAULT 'None';

ALTER TABLE "Exercises" ALTER COLUMN "Difficulty" TYPE text;
ALTER TABLE "Exercises" ALTER COLUMN "Difficulty" SET DEFAULT 'None';

ALTER TABLE "Exercises" ALTER COLUMN "Category" TYPE text;
ALTER TABLE "Exercises" ALTER COLUMN "Category" SET DEFAULT 'None';

ALTER TABLE "AspNetUsers" ALTER COLUMN "SportType" TYPE text;
UPDATE "AspNetUsers" SET "SportType" = 'None' WHERE "SportType" IS NULL;
ALTER TABLE "AspNetUsers" ALTER COLUMN "SportType" SET NOT NULL;
ALTER TABLE "AspNetUsers" ALTER COLUMN "SportType" SET DEFAULT 'None';

INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('0d7f67e9-90ee-40cc-9dce-89bd0cf06a95', NULL, 'User', 'USER');
INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('41c9c3b1-e49e-4b66-b562-fa61cf5a6a16', NULL, 'Administrator', 'ADMINISTRATOR');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240323054929_AddMoreModelConfiguration', '7.0.9');

COMMIT;

