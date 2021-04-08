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
-- add email firstname last name


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

--     CREATE TABLE projects  (
--     id int NOT NULL AUTO_INCREMENT,
--     projectname VARCHAR(80) NOT NULL,
--     creatoremail VARCHAR(100) NOT NULL,  
--     PRIMARY KEY (id)
-- );

    CREATE TABLE testticket  (
    id int NOT NULL AUTO_INCREMENT,
    creatoremail VARCHAR(100) NOT NULL,  
    testname VARCHAR(100) NOT NULL,
    priorityLevel VARCHAR(100) NOT NULL,
    assignedto VARCHAR(100) NOT NULL, 
    setup VARCHAR(100) NOT NULL,  
    steps VARCHAR(100) NOT NULL,  
    verifications VARCHAR(100) NOT NULL, 
    automate TINYINT NOT NULL,
    relatedFeature VARCHAR(100) NOT NULL,  
    jiraticket VARCHAR(100) NOT NULL,  
    notes VARCHAR(100) NOT NULL,  
    filepath VARCHAR(100),  
    webstatus VARCHAR(100),  
    androidstatus VARCHAR(100),  
    iosstatus VARCHAR(100),  

    PRIMARY KEY (id)
);