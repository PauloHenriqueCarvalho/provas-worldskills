USE TarefasDB;


CREATE TABLE Usuario(
	id INT PRIMARY KEY IDENTITY(1,1)  ,
	nome VARCHAR(255) NOT NULL,
	login VARCHAR(255) NOT NULL UNIQUE,
	senha VARCHAR(200) NOT NULL,
	dataCadastro DATETIME2 DEFAULT GETDATE()

);


CREATE TABLE Status(
	id INT PRIMARY KEY IDENTITY(1,1)  ,
	nome VARCHAR(255) NOT NULL,
	cor VARCHAR(255) NOT NULL DEFAULT '#333',
	dataCadastro DATETIME2 DEFAULT GETDATE()
);

CREATE TABLE Tarefa(
	id INT PRIMARY KEY IDENTITY(1,1)  ,
	usuarioRemetente int NOT NULL,
	status int ,
	usuarioDestinatario int NOT NULL,
	titulo VARCHAR(255) NOT NULL,
	descricao VARCHAR(MAX) NOT NULL,
	dataVencimento DATETIME2,
	dataCadastro DATETIME2 DEFAULT GETDATE(),
	FOREIGN KEY( status) REFERENCES Status(id),
	FOREIGN KEY(usuarioDestinatario) REFERENCES Usuario(id),
	FOREIGN KEY(usuarioRemetente) REFERENCES Usuario(id)

);

