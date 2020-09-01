-- DROP TABLE IF EXISTS  messages;

--     CREATE TABLE messages  (
--     id int NOT NULL AUTO_INCREMENT,
--     username VARCHAR(80) NOT NULL,
--     email VARCHAR(100) NOT NULL,  
--     website VARCHAR(255) ,
--     phonenumber VARCHAR(16) ,
--     PRIMARY KEY (id)
-- );


--     CREATE TABLE organization  (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(80) ,
--     email VARCHAR(100) ,  
--     logoUrl VARCHAR(255),
--     city VARCHAR(100) ,
--     state VARCHAR(100) ,
--     address VARCHAR(100) ,
--     phoneNumber VARCHAR(16) ,
--     PRIMARY KEY (id)
-- );


--     CREATE TABLE fundraiser  (
--     id int NOT NULL AUTO_INCREMENT,
--     active TINYINT(4) NOT NULL,
--     title VARCHAR(100) NOT NULL,
--     description VARCHAR(800) NOT NULL,  
--     link VARCHAR(255) NOT NULL,
--     goal VARCHAR(16) NOT NULL,
--     currentAmount VARCHAR(255) DEFAULT 0,
--     organizationId int NOT NULL,
--     PRIMARY KEY (id)
-- );
