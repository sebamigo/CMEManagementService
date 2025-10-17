CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;
CREATE TABLE "EducationCourses" (
    "EducationCourseId" TEXT NOT NULL CONSTRAINT "PK_EducationCourses" PRIMARY KEY
);

CREATE TABLE "Personnel" (
    "PersonnelId" TEXT NOT NULL CONSTRAINT "PK_Personnel" PRIMARY KEY,
    "FirstName" TEXT NOT NULL,
    "LastName" TEXT NOT NULL,
    "Email" TEXT NOT NULL,
    "Discriminator" TEXT NOT NULL,
    "Specialty" TEXT NULL,
    "LicenseNumber" TEXT NULL,
    "Certification" TEXT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20251017083623_init', '9.0.10');

CREATE TABLE "PersonnelParticipations" (
    "PersonnelId" TEXT NOT NULL,
    "EducationCourseId" TEXT NOT NULL,
    "NumberOfParticipations" INTEGER NOT NULL,
    CONSTRAINT "PK_PersonnelParticipations" PRIMARY KEY ("PersonnelId", "EducationCourseId"),
    CONSTRAINT "FK_PersonnelParticipations_EducationCourses_EducationCourseId" FOREIGN KEY ("EducationCourseId") REFERENCES "EducationCourses" ("EducationCourseId") ON DELETE CASCADE,
    CONSTRAINT "FK_PersonnelParticipations_Personnel_PersonnelId" FOREIGN KEY ("PersonnelId") REFERENCES "Personnel" ("PersonnelId") ON DELETE CASCADE
);

CREATE INDEX "IX_PersonnelParticipations_EducationCourseId" ON "PersonnelParticipations" ("EducationCourseId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20251017152743_personnelparticipation', '9.0.10');

ALTER TABLE "EducationCourses" ADD "CreditHours" INTEGER NOT NULL DEFAULT 0;

ALTER TABLE "EducationCourses" ADD "Description" TEXT NULL;

ALTER TABLE "EducationCourses" ADD "EndDate" TEXT NOT NULL DEFAULT '0001-01-01 00:00:00';

ALTER TABLE "EducationCourses" ADD "StartDate" TEXT NOT NULL DEFAULT '0001-01-01 00:00:00';

ALTER TABLE "EducationCourses" ADD "Title" TEXT NOT NULL DEFAULT '';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20251017153712_coursecontroller', '9.0.10');

ALTER TABLE "PersonnelParticipations" RENAME COLUMN "NumberOfParticipations" TO "HasCompleted";

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20251017210236_changedNumOFPartToBool', '9.0.10');

COMMIT;

