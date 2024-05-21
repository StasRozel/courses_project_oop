CREATE DATABASE TicketSystem;
GO

USE TicketSystem;

-- Таблица 1: Tickets (Билеты)
CREATE TABLE Tickets (
    Id INT PRIMARY KEY,
    [From] NVARCHAR(100) NOT NULL,
	[To] NVARCHAR(100) NOT NULL,
    [Time] TIME NOT NULL,
    Price FLOAT NOT NULL,
    NumberTrain INT NOT NULL,
    [Description] NVARCHAR(MAX) NOT NULL,
    [Type] NVARCHAR(50) NOT NULL
);	

-- Таблица 2: Users (Пользователи)
CREATE TABLE Users (
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
	Surname NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL PRIMARY KEY,
	PasswordHash NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20) NULL,
	isAdmin bit NOT NULL
);

SELECT * FROM Users;

-- Таблица 3: PurchasedTickets (Купленные билеты)
CREATE TABLE PurchasedTickets (
    PurchaseId INT PRIMARY KEY,
    EmailUser NVARCHAR(100) NOT NULL FOREIGN KEY REFERENCES Users(Email),
    TicketId INT NOT NULL FOREIGN KEY REFERENCES Tickets(Id),
	[From] NVARCHAR(100) NOT NULL,
	[To] NVARCHAR(100) NOT NULL,
    PurchaseTime TIME NOT NULL DEFAULT GETDATE(),
    Price FLOAT NOT NULL,
    NumberTrain INT NOT NULL,
	Status INT NOT NULL DEFAULT 0,
	[Type] NVARCHAR(50) NOT NULL
);


SELECT * FROM PurchasedTickets

INSERT INTO Tickets(Id,  [From], [To], [Time], Price, NumberTrain, [Description], [Type])
VALUES
    (1, 'Витебск', 'Орша', '10:30:00', 56, 6342, 'Маршрут проходит через станции: Витебск → Докшицы → Бешенковичи → Орша', 'train'),
    (2, 'Минск ', 'Брест', '15:45:00', 75, 2501, 'Маршрут проходит через станции: Минск → Столбцы → Ивацевичи → Кобрин → Брест','train'),
    (3, 'Гомель ', 'Могилев', '08:00:00', 48, 4101, ' Маршрут проходит через станции: Гомель → Добруш → Жлобин → Кричев → Могилев', 'train'),
    (4, 'Брест ', 'Пинск', '17:10:00', 65, 2701, 'Маршрут проходит через станции: Брест → Высокое → Хотислав → Иваново → Пинск', 'train'),
    (5, 'Могилев ', 'Бобруйск', '11:45:00', 42, 4201, 'Маршрут проходит через станции: Могилев → Шклов → Салтановка → Березино → Бобруйск', 'train'),
    (6, 'Пинск ', 'Барановичи', '14:30:00', 55, 2801, 'Маршрут проходит через станции: Пинск → Логишин → Ганцевичи → Барановичи', 'train'),
    (7, 'Бобруйск ', 'Жлобин', '16:15:00', 45, 4301, 'Маршрут проходит через станции: Бобруйск → Глуск → Осиповичи → Жлобин', 'train'),
    (8, 'Слоним ', 'Барановичи', '13:40:00', 35, 3401, 'Маршрут проходит через станции: Слоним → Новоельня → Дятлово → Барановичи', 'electric'),
    (9, 'Минск ', 'Сморгонь', '11:00:00', 13, 1122, 'Минск - Сморгонь', 'electric'),
    (10,'Минск ', 'Иваново', '14:20:00', 20, 5421, 'Минск - Иваново', 'electric'),
    (11, 'Минск ', 'Витебск', '13:20:00', 12, 4312, 'Минск - Витебск', 'electric'),
    (12, 'Минск ', 'Гродно', '13:40:00', 29, 5413, 'Минск - Гродно', 'train'),
    (13, 'Минск','Глубокое', '19:20:00', 24, 5111, 'Минск - Глубокое(МКК)', 'electric'),
    (14, 'Гудогай', 'Минск', '12:30:00', 15, 1223, 'Минск','electric'),
    (15, 'Минск', 'Липецк', '13:30:00', 12, 4123, 'Минск-Орша-Ошмяны-Липецк', 'electric');