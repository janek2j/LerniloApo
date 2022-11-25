-- Creating database schema
PRAGMA foreign_keys=off;

BEGIN TRANSACTION;

CREATE TABLE IF NOT EXISTS deck (
  id INT PRIMARY KEY,
  name VARCHAR(50) NOT NULL,
  description VARCHAR(1000) DEFAULT NULL,
  user_id INT NOT NULL, -- FOREIGN KEY
  CONSTRAINT fk_deck_user FOREIGN KEY (user_id) 
  REFERENCES app_user (id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS card (
  id INT PRIMARY KEY,
  front TEXT NOT NULL,
  back TEXT NOT NULL,
  img TEXT DEFAULT NULL,
  create_datetime TIMESTAMP,
  card_type TEXT DEFAULT "front-back" NOT NULL,
  deck_id INT DEFAULT 0,
  CONSTRAINT fk_card_deck FOREIGN KEY (deck_id) REFERENCES deck (id) ON DELETE NO ACTION ON UPDATE CASCADE
  );


CREATE TABLE IF NOT EXISTS app_user (
  id INT,
  username VARCHAR(30) NOT NULL UNIQUE,
  email VARCHAR(50) NOT NULL UNIQUE
    CHECK(length(email) >= 5),
  password TEXT NOT NULL,
  registration_date TIMESTAMP -- NOT NULL
  lang VARCHAR(2) DEFAULT "pl" NOT NULL,
  active CHAR(1) DEFAULT 'Y' NOT NULL,
  PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS answer (
  id INT PRIMARY KEY,
  card_id INT NOT NULL,
  deck_id INT NOT NULL,
  answer_datetime TIMESTAMP -- NOT NULL  
);


CREATE TABLE IF NOT EXISTS _variables (
  name VARCHAR(20),
  val TEXT
);


COMMIT;

PRAGMA foreign_keys=on;
