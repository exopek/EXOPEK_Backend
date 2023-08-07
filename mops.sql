START TRANSACTION;

ALTER TABLE "Image" DROP CONSTRAINT "FK_Image_Workouts_WorkoutId";

ALTER TABLE "Image" ALTER COLUMN "WorkoutId" DROP NOT NULL;

ALTER TABLE "Image" ADD CONSTRAINT "FK_Image_Workouts_WorkoutId" FOREIGN KEY ("WorkoutId") REFERENCES "Workouts" ("Id");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230804080402_2023-08-04-js-1', '7.0.9');

COMMIT;

