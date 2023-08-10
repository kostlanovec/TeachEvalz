CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Persons" (
    "PersonId" INTEGER NOT NULL CONSTRAINT "PK_Persons" PRIMARY KEY AUTOINCREMENT,
    "Password" TEXT NOT NULL,
    "FirstName" TEXT NOT NULL,
    "LastName" TEXT NOT NULL,
    "Email" TEXT NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230810193139_InitialCreate', '7.0.10');

COMMIT;

