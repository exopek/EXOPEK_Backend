START TRANSACTION;

DELETE FROM "AspNetRoles"
WHERE "Id" = '3cacdbdb-fd69-46fa-9683-69be99589487';

DELETE FROM "AspNetRoles"
WHERE "Id" = '3f721173-9dfa-4264-b1db-8c3326f01e7b';

CREATE TABLE "PlanUserStatus" (
    "Id" uuid NOT NULL,
    "PlanId" uuid NOT NULL,
    "UserId" text NOT NULL,
    "CurrentPhase" integer NOT NULL,
    CONSTRAINT "PK_PlanUserStatus" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_PlanUserStatus_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_PlanUserStatus_Plans_PlanId" FOREIGN KEY ("PlanId") REFERENCES "Plans" ("Id") ON DELETE CASCADE
);

INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('424f26d9-c65a-462f-a2ca-4eaf9d69e415', '261dfded-9e6c-4aa2-907b-4cf3cf7c9036', 'User', 'USER');
INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
VALUES ('b0972fb5-37b9-45e7-8fa6-8bbc17f2db71', '61a5c606-5d67-4b94-94b4-81ef2c5bf900', 'Administrator', 'ADMINISTRATOR');

CREATE INDEX "IX_PlanUserStatus_PlanId" ON "PlanUserStatus" ("PlanId");

CREATE INDEX "IX_PlanUserStatus_UserId" ON "PlanUserStatus" ("UserId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231020070938_2023-10-20-js', '7.0.9');

COMMIT;

