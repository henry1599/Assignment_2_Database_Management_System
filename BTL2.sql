CREATE DATABASE BUS_SYSTEM;
USE BUS_SYSTEM;
-- DROP DATABASE BUS_SYSTEM;
-- Employee table
CREATE TABLE EMPLOYEE
(
	employee_id VARCHAR(8) PRIMARY KEY,
    first_name VARCHAR(100) ,
    last_name VARCHAR(100) ,
    age INT,
    start_date DATE,
    base_salary INT,
    current_salary INT,
    data_of_birth DATE,
    email VARCHAR(100),
    -- Male, Female or Unidentified (M, F, U)
    sex CHAR
);

SELECT * FROM EMPLOYEE;
-- Employee phonenumber table
CREATE TABLE EMPLOYEE_PHONENUMBER
(
	employee_id VARCHAR(8),
    phone_number VARCHAR(11),
    CONSTRAINT pk_employee_phonenumber_table PRIMARY KEY (employee_id, phone_number),
    FOREIGN KEY (employee_id) REFERENCES EMPLOYEE(employee_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- Employee address table
CREATE TABLE EMPLOYEE_ADDRESS
(
	employee_id VARCHAR(8),
    -- địa chỉ ( 268 Lý Thường Kiệt, Phường 14, Quận 10, Thành phố Hồ Chí Minh )
    address VARCHAR(100),
    CONSTRAINT pk_employee_address_table PRIMARY KEY (employee_id, address),
    FOREIGN KEY (employee_id) REFERENCES EMPLOYEE(employee_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- Operating staff table
CREATE TABLE OPERATING_STAFF
(
	staff_id VARCHAR(8) PRIMARY KEY,
    -- Tính bằng đơn vị WPM - Words per minute 
    typing_speed INT,
    FOREIGN KEY (staff_id) REFERENCES EMPLOYEE(employee_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- Operating staff degree table
CREATE TABLE OPERATING_STAFF_DEGREE
(
	staff_id VARCHAR(8),
    -- Bằng cấp có thể là tên trường hoặc tên bằng (cấp 1, cấp 2, đại học, harvard,...)
    degree VARCHAR(100),
    CONSTRAINT pk_operating_staff_degree_table PRIMARY KEY (staff_id, degree),
    FOREIGN KEY (staff_id) REFERENCES EMPLOYEE(employee_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- Assistant table
CREATE TABLE ASSISTANT
(
	assistant_id VARCHAR(8) PRIMARY KEY,
    FOREIGN KEY (assistant_id) REFERENCES EMPLOYEE(employee_id) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- Route table
CREATE TABLE ROUTE
(
	route_id VARCHAR(2) PRIMARY KEY,
    distance INT,
    operating_staff_id VARCHAR(8),
    FOREIGN KEY (operating_staff_id) REFERENCES OPERATING_STAFF(staff_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- Station table
CREATE TABLE STATION
(
	station_id VARCHAR(4) PRIMARY KEY,
    station_name VARCHAR(100),
    address VARCHAR(100),
    -- Theo đơn vị số xe bus
    storage INT
);
-- Bus route table
CREATE TABLE BUS_ROUTE
(
	route_id VARCHAR(2) PRIMARY KEY,
    -- Nội thành hoặc liên tỉnh
    -- N : nội thành
    -- L : liên tỉnh
    type_route CHAR,
    number_of_busstop INT,
    number_of_trip INT,
    FOREIGN KEY (route_id) REFERENCES ROUTE(route_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- Tour table
CREATE TABLE TOUR
(
	route_id VARCHAR(2) PRIMARY KEY,
    tour_name VARCHAR(100),
    duration INT,
    price INT,
    FOREIGN KEY (route_id) REFERENCES ROUTE(route_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);
-- Bus table
CREATE TABLE BUS
(
	license_plate_no VARCHAR(10) PRIMARY KEY,
    -- Xe lớn, vừa hoặc nhỏ (L, V, N)
    type_of_bus CHAR,
    number_of_seats INT
);

-- Trip bus table
CREATE TABLE TRIP_BUS
(
	route_id VARCHAR(2),
    trip_no INT,
    number_of_passengers INT,
    departure_time DATETIME,
    arrival_time DATETIME,
    earning INT,
    bus_license_plate_no VARCHAR(10),
    CONSTRAINT pk_trip_bus PRIMARY KEY (route_id, trip_no),
    FOREIGN KEY (route_id) REFERENCES ROUTE(route_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
    FOREIGN KEY (bus_license_plate_no) REFERENCES BUS(license_plate_no)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- Bus stop table
CREATE TABLE BUS_STOP
(
	bus_stop_id VARCHAR(5) PRIMARY KEY,
    bus_stop_name VARCHAR(100),
    bus_stop_address VARCHAR(100)
);

-- Trip tour table
CREATE TABLE TRIP_TOUR
(
	route_id VARCHAR(2),
    trip_no INT,
    number_of_passengers INT,
    departure_time DATETIME,
    arrival_time DATETIME,
    CONSTRAINT pk_trip_tour PRIMARY KEY (route_id, trip_no),
    FOREIGN KEY (route_id) REFERENCES ROUTE(route_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- Destination table
CREATE TABLE DESTINATION
(
	destination_id VARCHAR(10) PRIMARY KEY,
    destination_name VARCHAR(100),
    address VARCHAR(100)
);

-- Ticket table
CREATE TABLE TICKET
(
	ticket_id VARCHAR(10),
    -- M : member card
    -- N : non-member card
    -- T : monthly payment
    type_ticket CHAR,
    price INT,
    payment_id VARCHAR(11) PRIMARY KEY,
    route_id VARCHAR(2),
    trip_no INT,
    FOREIGN KEY (route_id) REFERENCES ROUTE(route_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);
-- Member card table
CREATE TABLE MEMBER_CARD
(
	payment_id VARCHAR(11),
    card_id VARCHAR(9),
    -- tiền còn lại trong tài khoản
    extant INT,
    CONSTRAINT pk_member_card PRIMARY KEY (payment_id, card_id),
    FOREIGN KEY (payment_id) REFERENCES TICKET(payment_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- Non-member table
CREATE TABLE NON_MEMBER_CARD
(
	payment_id VARCHAR(11) PRIMARY KEY,
    cash INT,
    FOREIGN KEY (payment_id) REFERENCES TICKET(payment_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- Monthly payment table
CREATE TABLE MONTHLY_PAYMENT_CARD
(
	payment_id VARCHAR(11),
    card_id VARCHAR(9),
    expired_date DATE,
    CONSTRAINT pk_monthly_payment_card PRIMARY KEY (payment_id, card_id),
    FOREIGN KEY (payment_id) REFERENCES TICKET(payment_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- Dependent table
CREATE TABLE DEPENDENT
(
	employee_id VARCHAR(8),
    employee_name VARCHAR(100),
    sex CHAR,
    birthday DATE,
    relation VARCHAR(100),
    CONSTRAINT pk_dependent PRIMARY KEY (employee_id, employee_name),
    FOREIGN KEY (employee_id) REFERENCES EMPLOYEE(employee_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- Dependent phone number table
CREATE TABLE DEPENDENT_PHONE_NUMBER
(
	employee_id VARCHAR(8),
    employee_name VARCHAR(100),
    phone_number VARCHAR(11),
    CONSTRAINT pk_dependent_phone_number PRIMARY KEY (employee_id, employee_name, phone_number),
    FOREIGN KEY (employee_id) REFERENCES EMPLOYEE(employee_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);



-- Driver table
CREATE TABLE DRIVER
(
	driver_id VARCHAR(8) PRIMARY KEY,
    driver_license VARCHAR(20),
    FOREIGN KEY (driver_id) REFERENCES EMPLOYEE(employee_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- Booking table
CREATE TABLE BOOKING
(
	order_id VARCHAR(5) PRIMARY KEY,
    departure_destination VARCHAR(100),
    departure_time DATETIME,
    arrival_time DATETIME,
    number_of_passengers INT,
    price INT,
    operating_staff_id VARCHAR(8),
    receive_order_time DATETIME,
    FOREIGN KEY (operating_staff_id) REFERENCES OPERATING_STAFF(staff_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- On bus table
CREATE TABLE ON_BUS
(
	driver_id VARCHAR(8),
    assistant_id VARCHAR(8),
    route_id VARCHAR(2),
    trip_no INT,
    CONSTRAINT pk_on_bus PRIMARY KEY (driver_id, assistant_id, route_id, trip_no),
    FOREIGN KEY (driver_id) REFERENCES DRIVER(driver_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
    FOREIGN KEY (route_id) REFERENCES ROUTE(route_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- On tour table
CREATE TABLE ON_TOUR
(
	driver_id VARCHAR(8),
    bus_license_plate_no VARCHAR(10),
    route_id VARCHAR(2),
    trip_no INT,
    CONSTRAINT pk_on_tour PRIMARY KEY (route_id, trip_no),
    FOREIGN KEY (route_id) REFERENCES ROUTE(route_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- On book table
CREATE TABLE ON_BOOK
(
	driver_id VARCHAR(8),
    bus_license_plate_no VARCHAR(10),
    route_id VARCHAR(2),
    trip_no INT,
    CONSTRAINT pk_on_tour PRIMARY KEY (route_id, trip_no),
    FOREIGN KEY (route_id) REFERENCES ROUTE(route_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- Bus route constraint
CREATE TABLE BUS_ROUTE_CONTAINS
(
	route_id VARCHAR(2),
    bus_stop_id VARCHAR(5),
    -- From 1..n
    bus_stop_order INT,
    CONSTRAINT pk_bus_route_contains PRIMARY KEY (route_id, bus_stop_id),
    FOREIGN KEY (bus_stop_id) REFERENCES BUS_STOP(bus_stop_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- Tour route contains
CREATE TABLE TOUR_ROUTE_CONTAINS
(
	route_id VARCHAR(2),
    destination_id VARCHAR(10),
    -- From 1..n 
    destination_order INT,
    -- In minutes
    waiting_time INT,
    CONSTRAINT pk_tour_route_contains PRIMARY KEY (route_id, destination_id),
    FOREIGN KEY (destination_id) REFERENCES DESTINATION(destination_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- Station in route 
CREATE TABLE STATION_IN_ROUTE
(
	route_id VARCHAR(2),
    station_id VARCHAR(4),
    is_departure_station BOOLEAN,
    CONSTRAINT pk_station_in_route PRIMARY KEY (route_id, station_id),
    FOREIGN KEY (station_id) REFERENCES STATION(station_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

select * from EMPLOYEE

INSERT INTO EMPLOYEE VALUES('ATATATAT','AAAA','aaaa',20,'2020-12-20',10000,20000,'2001-02-11','example@gmail.com','F');
INSERT INTO EMPLOYEE VALUES('BTBTBTBT','BBBB','bbbb',21,'2020-12-21',10001,20001,'2001-02-12','example1@gmail.com','F');
INSERT INTO EMPLOYEE VALUES('CTCTCTCT','CCCC','cccc',22,'2020-12-22',10002,20002,'2001-02-13','example2@gmail.com','F');
INSERT INTO EMPLOYEE VALUES('DTDTDTDT','DDDD','dddd',23,'2020-12-23',10003,20003,'2001-02-14','example3@gmail.com','F');
INSERT INTO EMPLOYEE VALUES('ETETETET','EEEE','eeee',24,'2020-12-24',10004,20004,'2001-02-15','example4@gmail.com','F');
INSERT INTO EMPLOYEE VALUES('FTFTFTFT','FFFF','ffff',25,'2020-12-25',10005,20005,'2001-02-16','example5@gmail.com','F');
INSERT INTO EMPLOYEE VALUES('GTGTGTGT','GGGG','gggg',26,'2020-12-26',10006,20006,'2001-02-17','example6@gmail.com','F');
DELETE FROM EMPLOYEE WHERE employee_id = 'ATATATAT' AND first_name = 'AAAA';
	