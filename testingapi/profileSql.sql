-- DROP TABLE IF EXISTS  profile;
-- DROP TABLE IF EXISTS  ticket;
-- DROP TABLE IF EXISTS  projectContributors;
-- DROP TABLE IF EXISTS  ticket;

-- CREATE TABLE profile (
-- id int NOT NULL AUTO_INCREMENT,
-- email VARCHAR(50), 
-- name VARCHAR(50),
-- PRIMARY KEY (id)
-- );

-- CREATE TABLE userProject (
-- projectId int NOT NULL AUTO_INCREMENT,
-- creatorEmail VARCHAR(80),
-- name VARCHAR(50),
-- PRIMARY KEY (projectId)
-- );

-- CREATE TABLE projectContributors (
-- projectContributorId int NOT NULL AUTO_INCREMENT,
-- userId int NOT NULL,
-- projectId int NOT NULL,
-- role VARCHAR(20) NOT NULL,
-- PRIMARY KEY (projectContributorId)
-- );

-- CREATE TABLE ticket  (
-- ticketId int NOT NULL AUTO_INCREMENT,
-- creatorId int NOT NULL,
-- projectId int NOT NULL,
-- creatorEmail VARCHAR(100) NOT NULL,  
-- testName VARCHAR(100) NOT NULL,
-- priorityLevel VARCHAR(100),
-- assignedTo VARCHAR(100), 
-- setup VARCHAR(100) NOT NULL,  
-- steps VARCHAR(100) NOT NULL,  
-- verifications VARCHAR(100) NOT NULL, 
-- automate TINYINT,
-- relatedFeature VARCHAR(100),  
-- jiraTicket VARCHAR(100),  
-- notes VARCHAR(100) ,  
-- filePath VARCHAR(100),  
-- webStatus VARCHAR(100),  
-- androidStatus VARCHAR(100),  
-- iosStatus VARCHAR(100),  
-- PRIMARY KEY (ticketId)
-- );

