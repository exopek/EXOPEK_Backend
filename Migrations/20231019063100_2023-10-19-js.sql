START TRANSACTION;

DELETE FROM "AspNetRoles"
WHERE "Id" = '5b97f80e-c096-4368-93b7-6ce3f68030e4';

DELETE FROM "AspNetRoles"
WHERE "Id" = 'b2c9cae7-5948-4d89-a21e-8421595d8065';

CREATE TABLE "Plans" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Description" text NULL,
    "PreviewImageUrl" text NOT NULL,
    "CreatedAt" timestamp with time zone NULL,
    "Difficulty" integer NOT NULL,
    "Target" integer NOT NULL,
    "Hashtags" text NULL,
    "VideoUrl" text NULL,
    "Duration" double precision NOT NULL,
    CONSTRAINT "PK_Plans" PRIMARY KEY ("Id")
);

CREATE TABLE "PlanWorkout" (
    "Id" uuid NOT NULL,
    "PlanId" uuid NOT NULL,
    "WorkoutId" uuid NOT NULL,
    "PhaseType" integer NOT NULL,
    CONSTRAINT "PK_PlanWorkout" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_PlanWorkout_Plans_PlanId" FOREIGN KEY ("PlanId") REFERENCES "Plans" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_PlanWorkout_Workouts_WorkoutId" FOREIGN KEY ("WorkoutId") REFERENCES "Workouts" ("Id") ON DELETE CASCADE
);

INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('3cacdbdb-fd69-46fa-9683-69be99589487', '9db714ab-7a8f-4d0b-9439-7f9a005d2235', 'User', 'USER');
INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('3f721173-9dfa-4264-b1db-8c3326f01e7b', '59d84c1e-5b48-46ec-8ac0-44e723fcf816', 'Administrator', 'ADMINISTRATOR');

CREATE INDEX "IX_PlanWorkout_PlanId" ON "PlanWorkout" ("PlanId");

CREATE INDEX "IX_PlanWorkout_WorkoutId" ON "PlanWorkout" ("WorkoutId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231019063100_2023-10-19-js', '7.0.9');

COMMIT;

