USE "copenhagen_airport";

DROP TABLE IF EXISTS "departure";
DROP TABLE IF EXISTS "extra_permitted_route_operators";
DROP TABLE IF EXISTS "airline_company";
DROP TABLE IF EXISTS "route";
DROP TABLE IF EXISTS "airport";

CREATE TABLE "airport" (
    "id" int PRIMARY KEY IDENTITY(1,1),
    "iata" varchar(3) UNIQUE,
    "name" varchar(240)
)

CREATE TABLE "route" (
    "id" int PRIMARY KEY IDENTITY(1,1),
    "name" varchar(240),
    "origin_id" int NOT NULL,
    "destination_id" int NOT NULL,
    "owning_company_id" int NOT NULL,
    "owner_operates_this_route" BIT NOT NULL DEFAULT 1
    FOREIGN KEY (origin_id) REFERENCES airport(id),
    FOREIGN KEY (destination_id) REFERENCES airport(id)
)

CREATE TABLE "airline_company" (
    "id" int PRIMARY KEY IDENTITY(1,1),
    "name" varchar(240) UNIQUE
)

CREATE TABLE "extra_permitted_route_operators" (
    "airline_company_id" int NOT NULL,
    "route_id" int NOT NULL,
    FOREIGN KEY (airline_company_id) REFERENCES airline_company(id),
    FOREIGN KEY (route_id) REFERENCES  route(id)
)

CREATE TABLE "departure" (
    "id" int NOT NULL PRIMARY KEY IDENTITY(1,1),
    "route_id" int NOT NULL,
    "time_of_departure" DATETIME NOT NULL,
    "operator_id" int NOT NULL,
    FOREIGN KEY (route_id) REFERENCES route(id),
    FOREIGN KEY (operator_id) REFERENCES airline_company(id)
)


INSERT INTO "airport" (iata, name)
VALUES
       ('LAX', 'Los Angeles International Airport'),
       ('CPH', 'Kastrup Lufthavn'),
       ('AMS', 'Amsterdam')
;

INSERT INTO "airline_company" (name)
VALUES
    ('SAS'),
    ('KLM'),
    ('Air Nostrum')
;

INSERT INTO "route" (name, origin_id, destination_id, owning_company_id)
VALUES
       ('Amsterdam', 2, 1, 1) -- Fra CPH til AMS (ejet af SAS)

;

INSERT INTO "extra_permitted_route_operators" (airline_company_id, route_id)
VALUES
    (2, 1) -- KLM kan også flyve til Amsterdam, ruten er ejet af SAS.
;


