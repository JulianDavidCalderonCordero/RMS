CREATE DATABASE rms;

USE rms;

CREATE TABLE rooms(
	[id] [int] IDENTITY(1,1) NOT NULL,
	CONSTRAINT pk_rooms PRIMARY KEY NONCLUSTERED (id),
	[name] [varchar](50) NULL,
	capacity INT DEFAULT 0,
	[availability] BIT DEFAULT 0
);

CREATE TABLE bookings(
	[id] [int] IDENTITY(1,1) NOT NULL,
	CONSTRAINT pk_bookings PRIMARY KEY NONCLUSTERED (id),
	[room_id] [int] NOT NULL,
	CONSTRAINT fk_rooms_bookings FOREIGN KEY (id) REFERENCES rooms(id),
	[date] [datetime] NULL DEFAULT GETDATE(),
	[username] [varchar](50) NULL
);

CREATE PROCEDURE getAvailableRooms AS BEGIN SELECT * FROM rooms WHERE [availability] = 1 END;

CREATE PROCEDURE getRooms AS BEGIN SELECT * FROM rooms END;

CREATE PROCEDURE addNewRoom @name VARCHAR(50), @capacity INT, @availability BIT AS BEGIN INSERT INTO rooms ([name], capacity, [availability]) VALUES (@name, @capacity, @availability) END;

CREATE PROCEDURE updateRoom @id INT, @name VARCHAR(50), @capacity INT, @availability BIT AS BEGIN UPDATE rooms SET [name] = @name, capacity = @capacity, [availability] = @availability WHERE id = @id END;

CREATE PROCEDURE removeRoom @id INT AS BEGIN DELETE FROM rooms WHERE id = @id END;

CREATE PROCEDURE checkRoomAvailability @id INT AS BEGIN SELECT [availability] FROM rooms WHERE id = @id END;

CREATE PROCEDURE addNewBooking @room_id int, @date DATETIME, @username VARCHAR(50) AS BEGIN INSERT INTO bookings (room_id, [date], username) VALUES (@room_id, @date, @username) END;

CREATE PROCEDURE searchBooking @date DATETIME, @room_id INT AS BEGIN SELECT * FROM bookings WHERE [date] = @date OR room_id = @room_id END;

CREATE PROCEDURE getBookings AS BEGIN SELECT * FROM bookings END;

CREATE PROCEDURE cancelBooking @id INT AS BEGIN DELETE FROM bookings WHERE id = @id END;

CREATE PROCEDURE updateBooking @id INT, @room_id INT, @date DATETIME, @username VARCHAR(50) AS BEGIN UPDATE bookings SET room_id = @room_id, date = @date, username = @username END;
