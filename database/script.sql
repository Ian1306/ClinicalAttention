CREATE TABLE pacientes (
    id UUID PRIMARY KEY,
    nombre VARCHAR(150) NOT NULL,
    documento VARCHAR(30) NOT NULL UNIQUE,
    edad INT NOT NULL,
    estado VARCHAR(20) NOT NULL DEFAULT 'ACTIVO'
);

select * from pacientes

CREATE TABLE medicos (
    id UUID PRIMARY KEY,
    nombre VARCHAR(150) NOT NULL,
    especialidad VARCHAR(50) NOT NULL,
    disponible BOOLEAN NOT NULL DEFAULT TRUE,
    estado VARCHAR(20) NOT NULL DEFAULT 'ACTIVO'
);


CREATE TABLE solicitudes (
    id UUID PRIMARY KEY,
    paciente_id UUID NOT NULL,
    especialidad VARCHAR(50) NOT NULL,
    motivo VARCHAR(500) NOT NULL,
    prioridad VARCHAR(20) NOT NULL,
    estado VARCHAR(20) NOT NULL,
    fecha_creacion TIMESTAMP NOT NULL,
    medico_asignado_id UUID NULL,

    CONSTRAINT fk_solicitud_paciente FOREIGN KEY (paciente_id) REFERENCES pacientes(id),
    CONSTRAINT fk_solicitud_medico FOREIGN KEY (medico_asignado_id) REFERENCES medicos(id)
);

select * from solicitudes

CREATE TABLE historial_solicitudes (
    id UUID PRIMARY KEY,
    solicitud_id UUID NOT NULL,
    estado_anterior VARCHAR(20),
    estado_nuevo VARCHAR(20) NOT NULL,
    fecha TIMESTAMP NOT NULL,
    observacion VARCHAR(500),

    CONSTRAINT fk_historial FOREIGN KEY (solicitud_id) REFERENCES solicitudes(id)
);

select * from consultas
-- FUTURO (pero incluido)
CREATE TABLE consultas (
    id UUID PRIMARY KEY,
    solicitud_id UUID NOT NULL,
    medico_id UUID NOT NULL,
    diagnostico TEXT,
    tratamiento TEXT,
    fecha TIMESTAMP NOT NULL,

    CONSTRAINT fk_consulta_solicitud FOREIGN KEY (solicitud_id) REFERENCES solicitudes(id),
    CONSTRAINT fk_consulta_medico FOREIGN KEY (medico_id) REFERENCES medicos(id)
);
select * from recetas
CREATE TABLE recetas (
    id UUID PRIMARY KEY,
    consulta_id UUID NOT NULL,
    fecha TIMESTAMP NOT NULL,

    CONSTRAINT fk_receta_consulta FOREIGN KEY (consulta_id) REFERENCES consultas(id)
);

CREATE TABLE medicamentos (
    id UUID PRIMARY KEY,
    receta_id UUID NOT NULL,
    nombre VARCHAR(150),
    dosis VARCHAR(50),

    CONSTRAINT fk_medicamento_receta FOREIGN KEY (receta_id) REFERENCES recetas(id)
);