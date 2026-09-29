-- 1. CREACIÓN DE LA BASE DE DATOS
CREATE DATABASE OrbitaDB;
GO

USE OrbitaDB;
GO

-- 2. CREACIÓN DE TABLAS
CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario VARCHAR(50) UNIQUE NOT NULL,
    Password VARCHAR(50) NOT NULL,
    Rol VARCHAR(20) NOT NULL, -- Administrador, Coordinador, Auditor
    Estado BIT NOT NULL -- 1: Activo, 0: Inactivo
);

CREATE TABLE Misiones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(20) UNIQUE NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255),
    Prioridad VARCHAR(20) NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaFin DATE NOT NULL,
    Estado VARCHAR(20) NOT NULL, -- Planificada, EnEjecucion, Finalizada, Cancelada
    ResponsableId INT FOREIGN KEY REFERENCES Usuarios(Id)
);

CREATE TABLE Recursos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(20) UNIQUE NOT NULL,
    Modelo VARCHAR(100) NOT NULL,
    Tipo VARCHAR(30) NOT NULL, -- Dron, Rover, EstacionSensores
    Estado VARCHAR(20) NOT NULL, -- Disponible, Asignado, Mantenimiento
    
    -- Atributos específicos (Permiten NULL por la herencia en una sola tabla)
    Autonomia DECIMAL(10,2),       -- Para Dron y Rover
    Alcance DECIMAL(10,2),         -- Para Dron
    CostoPorHora DECIMAL(10,2),    -- Para Dron
    CapacidadCarga DECIMAL(10,2),  -- Para Rover
    CostoPorKilometro DECIMAL(10,2),-- Para Rover
    CantidadSensores INT,          -- Para EstacionSensores
    ConsumoEnergetico DECIMAL(10,2),-- Para EstacionSensores
    CostoDiario DECIMAL(10,2)      -- Para EstacionSensores
);

CREATE TABLE Asignaciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MisionId INT FOREIGN KEY REFERENCES Misiones(Id),
    RecursoId INT FOREIGN KEY REFERENCES Recursos(Id)
);
GO

-- 3. INSERCIÓN DE DATOS DE PRUEBA OBLIGATORIOS

-- Usuarios (3 roles diferentes)
INSERT INTO Usuarios (NombreUsuario, Password, Rol, Estado) VALUES 
('admin_master', '12345', 'Administrador', 1),
('coord_operaciones', '12345', 'Coordinador', 1),
('auditor_externo', '12345', 'Auditor', 1);

-- Recursos: 3 Drones
INSERT INTO Recursos (Codigo, Modelo, Tipo, Estado, Autonomia, Alcance, CostoPorHora) VALUES 
('DRN-001', 'Falcon X1', 'Dron', 'Disponible', 4.5, 15.0, 120.00),
('DRN-002', 'Falcon X2', 'Dron', 'Mantenimiento', 6.0, 25.0, 150.00), -- Al menos uno en mantenimiento
('DRN-003', 'Scout Pro', 'Dron', 'Asignado', 2.5, 10.0, 85.00);

-- Recursos: 3 Rovers
INSERT INTO Recursos (Codigo, Modelo, Tipo, Estado, Autonomia, CapacidadCarga, CostoPorKilometro) VALUES 
('RVR-001', 'Titan T1', 'Rover', 'Asignado', 500.0, 250.0, 15.50),
('RVR-002', 'Titan T2', 'Rover', 'Disponible', 650.0, 300.0, 18.00),
('RVR-003', 'Explorer Mini', 'Rover', 'Disponible', 200.0, 50.0, 8.50);

-- Recursos: 3 Estaciones de Sensores
INSERT INTO Recursos (Codigo, Modelo, Tipo, Estado, CantidadSensores, ConsumoEnergetico, CostoDiario) VALUES 
('EST-001', 'Nexus Alpha', 'EstacionSensores', 'Asignado', 12, 45.5, 300.00),
('EST-002', 'Nexus Beta', 'EstacionSensores', 'Disponible', 24, 85.0, 550.00),
('EST-003', 'Eco Mon', 'EstacionSensores', 'Disponible', 6, 15.0, 100.00);

-- Misiones (4 Misiones en diferentes estados)
INSERT INTO Misiones (Codigo, Nombre, Descripcion, Prioridad, FechaInicio, FechaFin, Estado, ResponsableId) VALUES 
('MIS-001', 'Exploración Cañón Norte', 'Mapeo topográfico', 'Alta', '2026-10-01', '2026-10-15', 'EnEjecucion', 2),
('MIS-002', 'Análisis de Suelo', 'Recolección de muestras minerales', 'Media', '2026-09-01', '2026-09-20', 'Finalizada', 2),
('MIS-003', 'Vigilancia Fronteriza', 'Monitoreo de perímetro', 'Alta', '2026-11-01', '2026-11-30', 'Planificada', 2),
('MIS-004', 'Rescate Equipo Alpha', 'Búsqueda de sonda perdida', 'Urgente', '2026-08-01', '2026-08-05', 'Cancelada', 2);

-- Asignaciones (Simulando los recursos actualmente "Asignados" a la misión "EnEjecucion")
INSERT INTO Asignaciones (MisionId, RecursoId) VALUES 
(1, 3), -- DRN-003 asignado a MIS-001
(1, 4), -- RVR-001 asignado a MIS-001
(1, 7); -- EST-001 asignado a MIS-001
GO

INSERT INTO Usuarios (NombreUsuario, Password, Rol, Estado) 
VALUES ('Douglas', '12345', 'Administrador', 1);
GO