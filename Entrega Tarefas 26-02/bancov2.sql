DROP DATABASE TarefasDB_v2
CREATE DATABASE TarefasDB_v2;
GO

USE TarefasDB_v2;
GO

CREATE TABLE Usuario (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(150) NOT NULL,
    Login NVARCHAR(150) NOT NULL UNIQUE,
    SenhaHash NVARCHAR(255) NOT NULL,
    DataCadastro DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

CREATE TABLE Board (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(150) NOT NULL,
    UsuarioCriadorId INT NOT NULL,
    DataCadastro DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    CONSTRAINT FK_Board_Usuario
        FOREIGN KEY (UsuarioCriadorId)
        REFERENCES Usuario(Id)
        ON DELETE NO ACTION
);

CREATE TABLE BoardUsuario (
    BoardId INT NOT NULL,
    UsuarioId INT NOT NULL,

    CONSTRAINT PK_BoardUsuario
        PRIMARY KEY (BoardId, UsuarioId),

    CONSTRAINT FK_BoardUsuario_Board
        FOREIGN KEY (BoardId)
        REFERENCES Board(Id)
        ON DELETE CASCADE,

    CONSTRAINT FK_BoardUsuario_Usuario
        FOREIGN KEY (UsuarioId)
        REFERENCES Usuario(Id)
        ON DELETE NO ACTION
);

CREATE TABLE Coluna (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(150) NOT NULL,
    Cor VARCHAR(7) NOT NULL DEFAULT '#333333',
    Ordem INT NOT NULL,
    BoardId INT NOT NULL,
    DataCadastro DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    CONSTRAINT FK_Coluna_Board
        FOREIGN KEY (BoardId)
        REFERENCES Board(Id)
        ON DELETE CASCADE
);

CREATE TABLE Tarefa (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    BoardId INT NOT NULL,
    ColunaId INT NOT NULL,
    Titulo NVARCHAR(200) NOT NULL,
    Descricao NVARCHAR(MAX) NOT NULL,
    DataVencimento DATETIME2 NULL,
    DataCadastro DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    CONSTRAINT FK_Tarefa_Board
        FOREIGN KEY (BoardId)
        REFERENCES Board(Id)
        ON DELETE CASCADE,

    CONSTRAINT FK_Tarefa_Coluna
        FOREIGN KEY (ColunaId)
        REFERENCES Coluna(Id),

    CONSTRAINT FK_Tarefa_UsuarioRemetente
        FOREIGN KEY (UsuarioRemetenteId)
        REFERENCES Usuario(Id),

    CONSTRAINT FK_Tarefa_UsuarioDestinatario
        FOREIGN KEY (UsuarioDestinatarioId)
        REFERENCES Usuario(Id)
);

CREATE TABLE TarefaUsuario (
    TarefaId INT NOT NULL,
    UsuarioId INT NOT NULL,
    CONSTRAINT PK_TarefaUsuario
        PRIMARY KEY (TarefaId, UsuarioId),

    CONSTRAINT FK_TarefaUsuario_Tarefa
        FOREIGN KEY (TarefaId)
        REFERENCES Tarefa(Id)
        ON DELETE CASCADE,

    CONSTRAINT FK_TarefaUsuario_Usuario
        FOREIGN KEY (UsuarioId)
        REFERENCES Usuario(Id)
);

CREATE INDEX IX_Tarefa_BoardId ON Tarefa(BoardId);
CREATE INDEX IX_Tarefa_ColunaId ON Tarefa(ColunaId);
CREATE INDEX IX_Tarefa_UsuarioDestinatario ON Tarefa(UsuarioDestinatarioId);