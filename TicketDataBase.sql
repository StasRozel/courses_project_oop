CREATE DATABASE TicketSystem;
GO

USE TicketSystem;

-- Таблица 1: Tickets (Билеты)
CREATE TABLE Tickets (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NameWay NVARCHAR(100) NOT NULL,
    [Time] TIME NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    NumberTrain INT NOT NULL,
    [Description] NVARCHAR(MAX) NOT NULL,
    [Type] NVARCHAR(50) NOT NULL
);	

-- Таблица 2: Users (Пользователи)
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PhoneNumber NVARCHAR(20) NULL,
	isAdmin bit NOT NULL
);

-- Таблица 3: PurchasedTickets (Купленные билеты)
CREATE TABLE PurchasedTickets (
    PurchaseId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    TicketId INT NOT NULL FOREIGN KEY REFERENCES Tickets(Id),
    PurchaseDate DATETIME NOT NULL DEFAULT GETDATE(),
    Price DECIMAL(10, 2) NOT NULL,
    NumberTrain INT NOT NULL,
	[Type] NVARCHAR(50) NOT NULL
);

INSERT INTO Tickets(NameWay, [Time], Price, NumberTrain, [Description], [Type])
VALUES
    ('Витебск - Орша', '10:30:00', 56, 6342, ' Маршрут проходит через станции: Витебск → Докшицы → Бешенковичи → Орша', 'train'),
    ('Минск - Брест', '15:45:00', 75, 2501, 'Маршрут проходит через станции: Минск → Столбцы → Ивацевичи → Кобрин → Брест','train'),
    ('Гомель - Могилев', '08:00:00', 48, 4101, ' Маршрут проходит через станции: Гомель → Добруш → Жлобин → Кричев → Могилев', 'train'),
    ('Брест - Пинск', '17:10:00', 65, 2701, 'Маршрут проходит через станции: Брест → Высокое → Хотислав → Иваново → Пинск', 'train'),
    ('Могилев - Бобруйск', '11:45:00', 42, 4201, 'Маршрут проходит через станции: Могилев → Шклов → Салтановка → Березино → Бобруйск', 'train'),
    ('Пинск - Барановичи', '14:30:00', 55, 2801, 'Маршрут проходит через станции: Пинск → Логишин → Ганцевичи → Барановичи', 'train'),
    ('Бобруйск - Жлобин', '16:15:00', 45, 4301, 'Маршрут проходит через станции: Бобруйск → Глуск → Осиповичи → Жлобин', 'train'),
    ('Слоним - Барановичи', '13:40:00', 35, 3401, 'Маршрут проходит через станции: Слоним → Новоельня → Дятлово → Барановичи', 'electric'),
    ('Минск - Сморгонь', '11:00:00', 13, 1122, 'Минск - Сморгонь', 'electric'),
    ('Минск - Иваново', '14:20:00', 20, 5421, 'Минск - Иваново', 'electric'),
    ('Минск - Витебск', '13:20:00', 12, 4312, 'Минск - Витебск', 'electric'),
    ('Минск - Гродно', '13:40:00', 29, 5413, 'Минск - Гродно', 'train'),
    ('Минск - Глубокое', '19:20:00', 24, 5111, 'Минск - Глубокое(МКК)', 'electric'),
    ('Гудогай - Минск', '12:30:00', 15, 1223, 'Минск','electric'),
    ('Минск - Липецк', '13:30:00', 12, 4123, 'Минск-Орша-Ошмяны-Липецк', 'electric');