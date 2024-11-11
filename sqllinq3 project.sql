
create schema if not exists projectSQL3;
use projectSQL3;

CREATE TABLE member_information (
    UID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Age INT);
    
CREATE TABLE Personal_Info (
    UID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DateOfBirth DATE,
    Gender CHAR(1),
    Nationality VARCHAR(50),
    MaritalStatus VARCHAR(20),
    SSN VARCHAR(20),
    PassportNumber VARCHAR(20),
    Religion VARCHAR(50),
    Hobbies VARCHAR(100),
    FOREIGN KEY (UID ) REFERENCES member_information(UID )
);

CREATE TABLE EducationInfo (
    UID  INT,
    HighSchoolName VARCHAR(100),
    HighSchoolGraduationYear INT,
    UniversityName VARCHAR(100),
    Degree VARCHAR(50),
    Major VARCHAR(50),
    GraduationYear INT,
    GPA DECIMAL(3, 2),
    Certifications VARCHAR(100),
    Scholarships VARCHAR(100),
    FOREIGN KEY (UID) REFERENCES Personal_Info(UID)
);


CREATE TABLE Address_information(
    UID  INT,
    AddressLine1 VARCHAR(100),
    AddressLine2 VARCHAR(100),
    City VARCHAR(50),
    State VARCHAR(50),
    ZipCode VARCHAR(10),
    Country VARCHAR(50),
    ResidentialStatus VARCHAR(50),
    DurationOfStayYears INT,
    FOREIGN KEY (UID ) REFERENCES member_information(UID )
);


CREATE TABLE BankDetails (
    UID  INT,
    BankName VARCHAR(100),
    AccountNumber VARCHAR(20),
    BankBranch VARCHAR(100),
    IFSCCode VARCHAR(20),
    AccountType VARCHAR(20),
    AccountHolderName VARCHAR(100),
    SwiftCode VARCHAR(20),
    BankCountry VARCHAR(50),
    Currency VARCHAR(10),
    FOREIGN KEY (UID ) REFERENCES Personal_Info(UID )
);


CREATE TABLE Contact_information(
    UID  INT,
    Email VARCHAR(100),
    PhoneNumber VARCHAR(15),
    AlternatePhoneNumber VARCHAR(15),
    EmergencyContactName VARCHAR(50),
    EmergencyContactRelation VARCHAR(50),
    EmergencyContactPhone VARCHAR(15),
    LinkedInProfile VARCHAR(100),
    FacebookProfile VARCHAR(100),
    TwitterHandle VARCHAR(50),
    FOREIGN KEY (UID ) REFERENCES Personal_Info(UID )
);

CREATE TABLE EmploymentInfo (
    UID  INT,
    EmployerName VARCHAR(100),
    JobTitle VARCHAR(100),
    StartDate DATE,
    EndDate DATE,
    JobDescription TEXT,
    Salary DECIMAL(10, 2),
    SupervisorName VARCHAR(100),
    SupervisorPhone VARCHAR(15),
    FOREIGN KEY (UID ) REFERENCES Personal_Info(UID )
);



INSERT INTO member_information VALUES  (1, 'John', 'Doe', 23);
 INSERT INTO member_information VALUES  (2, 'Jane','smith',24);
INSERT INTO Personal_Info VALUES 
(1, 'John', 'Doe', '2000-05-15', 'M', 'American', 'Single', '123-45-6789', 'X12345678', 'Christianity', 'Reading'),
(2, 'Jane', 'Smith', '1999-07-20', 'F', 'Canadian', 'Married', '987-65-4321', 'Y98765432', 'Atheism', 'Painting');
INSERT INTO Address_information VALUES 
(1, '123 Main St', 'Apt 4B', 'New York', 'NY', '10001', 'USA', 'Owned', 5),
(2, '456 Maple Ave', 'Suite 300', 'Toronto', 'ON', 'M5J 2H7', 'Canada', 'Rented', 3);
SELECT * FROM Address_information;
INSERT INTO BankDetails VALUES 
(1, 'Chase', '1111222233334444', 'NY Main', 'CHASUS33', 'Checking', 'John Doe', 'CHASUS33', 'USA', 'USD'),
(2, 'Bank of Canada', '9999888877776666', 'Toronto Downtown', 'BOC123', 'Savings', 'Jane Smith', 'BOC123', 'Canada', 'CAD');
SELECT * FROM BankDetails;

INSERT INTO Contact_information VALUES 
(1, 'john.doe@example.com', '555-1234', '555-5678', 'Alice Doe', 'Mother', '555-8765', 'linkedin.com/johndoe', 'facebook.com/johndoe', '@johnDoe'),
(2, 'jane.smith@example.com', '555-4321', '555-6789', 'Bob Smith', 'Father', '555-9876', 'linkedin.com/janesmith', 'facebook.com/janesmith', '@janeSmith');
SELECT * FROM Contact_information;



INSERT INTO EducationInfo VALUES 
(1, 'New York High', 2018, 'NYU', 'BSc', 'Computer Science', 2022, 3.8, 'Java Certified', 'None'),
(2, 'Toronto High', 2017, 'University of Toronto', 'BA', 'English', 2021, 3.6, 'TEFL Certification', 'None');
SELECT * FROM EducationInfo;

INSERT INTO EmploymentInfo VALUES 
(1, 'Google', 'Software Engineer', '2022-07-01', '2023-09-30', 'Developed software applications', 85000, 'Steve Jobs', '555-7890'),
(2, 'Microsoft', 'Content Writer', '2021-06-15', '2023-08-15', 'Created technical documentation', 60000, 'Bill Gates', '555-7891');
SELECT * FROM EmploymentInfo;


SELECT * FROM member_information;
SELECT * FROM Personal_Info;