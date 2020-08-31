    CREATE TABLE messages  (
    id int NOT NULL AUTO_INCREMENT,
    name VARCHAR(80) NOT NULL,
    email VARCHAR(100) NOT NULL,  
    body VARCHAR(255) ,
    phonenumber VARCHAR(16) ,
    PRIMARY KEY (id)
);

-- DROP TABLE IF EXISTS  messages;