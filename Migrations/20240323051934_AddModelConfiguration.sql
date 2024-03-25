START TRANSACTION;

ALTER TABLE "WorkoutExercise" DROP CONSTRAINT "FK_WorkoutExercise_Exercise_ExerciseId";

ALTER TABLE "Exercise" DROP CONSTRAINT "PK_Exercise";

DELETE FROM "AspNetRoles"
WHERE "Id" = '537da145-63ca-4758-a4d0-05ae61937fee';

DELETE FROM "AspNetRoles"
WHERE "Id" = '6d3c9580-acde-4bc5-9ff8-d4f20a222242';

ALTER TABLE "Exercise" RENAME TO "Exercises";

ALTER TABLE "PlanUserStatus" ALTER COLUMN "Status" TYPE text;
ALTER TABLE "PlanUserStatus" ALTER COLUMN "Status" SET DEFAULT 'Inactive';

ALTER TABLE "PlanUserStatus" ALTER COLUMN "CurrentPhase" TYPE text;
ALTER TABLE "PlanUserStatus" ALTER COLUMN "CurrentPhase" SET DEFAULT 'Phase1';

ALTER TABLE "Exercises" ADD CONSTRAINT "PK_Exercises" PRIMARY KEY ("Id");

INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('2a99994b-1de1-43e2-b6d7-5ddbc653b062', NULL, 'User', 'USER');
INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('2b0b5d4a-154a-4075-bad3-e28c1bf693dc', NULL, 'Administrator', 'ADMINISTRATOR');

ALTER TABLE "WorkoutExercise" ADD CONSTRAINT "FK_WorkoutExercise_Exercises_ExerciseId" FOREIGN KEY ("ExerciseId") REFERENCES "Exercises" ("Id") ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240323051934_AddModelConfiguration', '7.0.9');

COMMIT;

