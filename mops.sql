START TRANSACTION;

DELETE FROM "AspNetRoles"
WHERE "Id" = '1368b63f-9a1e-489b-803e-9dddca49c599';

DELETE FROM "AspNetRoles"
WHERE "Id" = '237b64f1-0ccd-486b-ae8c-c2c17e801847';

CREATE TABLE "WorkoutUserLikes" (
    "Id" uuid NOT NULL,
    "WorkoutId" uuid NOT NULL,
    "UserId" text NOT NULL,
    "IsLiked" boolean NOT NULL,
    "CreatedAt" timestamp with time zone NULL,
    CONSTRAINT "PK_WorkoutUserLikes" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_WorkoutUserLikes_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_WorkoutUserLikes_Workouts_WorkoutId" FOREIGN KEY ("WorkoutId") REFERENCES "Workouts" ("Id") ON DELETE CASCADE
);

INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('82e66898-617f-435c-8d4e-80cc7564754c', '83f99081-4953-43f7-85e6-6fab5a687b72', 'User', 'USER');
INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('86c36f83-a02c-4f2c-849f-58d6fcc2ce9d', '9d4a9ddf-346e-4be7-95b8-340dbc1e1c2e', 'Administrator', 'ADMINISTRATOR');

CREATE INDEX "IX_WorkoutUserLikes_UserId" ON "WorkoutUserLikes" ("UserId");

CREATE INDEX "IX_WorkoutUserLikes_WorkoutId" ON "WorkoutUserLikes" ("WorkoutId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230915090813_2023-09-15-2', '7.0.9');

COMMIT;

