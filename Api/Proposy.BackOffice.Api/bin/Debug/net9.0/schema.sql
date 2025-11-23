
    drop table if exists "User" cascade

    create table "User" (
        Id uuid not null,
       CreationTime timestamp,
       LastModificationTime timestamp,
       Name varchar(255) not null,
       Email varchar(255) not null,
       PasswordHash varchar(255) not null,
       primary key (Id)
    )

    create index ___indexable on "User" (CreationTime, LastModificationTime)
