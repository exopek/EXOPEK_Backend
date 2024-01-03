START TRANSACTION;

DELETE FROM "AspNetRoles"
WHERE "Id" = '82e66898-617f-435c-8d4e-80cc7564754c';

DELETE FROM "AspNetRoles"
WHERE "Id" = '86c36f83-a02c-4f2c-849f-58d6fcc2ce9d';

CREATE TABLE "WorkoutUserCompletes" (
    "Id" uuid NOT NULL,
    "WorkoutId" uuid NOT NULL,
    "UserId" text NOT NULL,
    "IsCompleted" boolean NOT NULL,
    "CreatedAt" timestamp with time zone NULL,
    CONSTRAINT "PK_WorkoutUserCompletes" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_WorkoutUserCompletes_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_WorkoutUserCompletes_Workouts_WorkoutId" FOREIGN KEY ("WorkoutId") REFERENCES "Workouts" ("Id") ON DELETE CASCADE
);

INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('5b97f80e-c096-4368-93b7-6ce3f68030e4', '5c7d4e4e-059b-4ed2-9d27-a9d4e6acf512', 'User', 'USER');
INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('b2c9cae7-5948-4d89-a21e-8421595d8065', '703a76c8-5087-4826-baf5-fe91a255ba61', 'Administrator', 'ADMINISTRATOR');

CREATE INDEX "IX_WorkoutUserCompletes_UserId" ON "WorkoutUserCompletes" ("UserId");

CREATE INDEX "IX_WorkoutUserCompletes_WorkoutId" ON "WorkoutUserCompletes" ("WorkoutId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230915093837_2023-09-15-3', '7.0.9');

COMMIT;

