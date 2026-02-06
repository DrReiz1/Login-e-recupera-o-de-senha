CREATE DATABASE IF NOT EXISTS sistema_login;
USE sistema_login;

CREATE TABLE IF NOT EXISTS usuarios (
	Nome VARCHAR(80) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Senha VARCHAR(255) NOT NULL,
    DataNascimento DATE NOT NULL
);

DESCRIBE usuarios;

SELECT * FROM usuarios;

CREATE TABLE IF NOT EXISTS recuperacao_senha (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Email VARCHAR(100),
    Token VARCHAR(200),
    ExpiraEm DATETIME
);

ALTER TABLE usuarios ADD Token VARCHAR(10);
ALTER TABLE usuarios ADD TokenExpira DATETIME;
