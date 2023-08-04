CREATE TABLE Comment (
    CommentId int  NOT NULL,
    Comments nvarchar(max)  NOT NULL,
    Whisper_WhispId int  NOT NULL,
    User_UserId int  NOT NULL,
    CONSTRAINT Comment_pk PRIMARY KEY  (CommentId)
);

CREATE TABLE FeedBack (
    FeedBackId int  NOT NULL,
    FeedBack nvarchar(max)  NOT NULL,
    Date date  NOT NULL,
    Squad_SquadId int  NOT NULL,
    User_UserId int  NOT NULL,
    CONSTRAINT FeedBack_pk PRIMARY KEY  (FeedBackId)
);

CREATE TABLE Image (
    ImgId int  NOT NULL,
    ImgURL nvarchar(max)  NOT NULL,
    Whisper_WhispId int  NOT NULL,
    CONSTRAINT Image_pk PRIMARY KEY  (ImgId)
);

CREATE TABLE "Like" (
    LikeID int  NOT NULL,
    "Like" int  NOT NULL,
    Whisper_WhispId int  NOT NULL,
    User_UserId int  NOT NULL,
    CONSTRAINT Like_pk PRIMARY KEY  (LikeID)
);

CREATE TABLE Materials (
    MatId int  NOT NULL,
    Material nvarchar(max)  NOT NULL,
    Topic nvarchar  NOT NULL,
    WhisperTopic_WTopicId int  NOT NULL,
    CONSTRAINT Materials_pk PRIMARY KEY  (MatId)
);

CREATE TABLE Notification (
    NotiId int  NOT NULL,
    Notiication nvarchar  NOT NULL,
    User_UserId int  NOT NULL,
    CONSTRAINT Notification_pk PRIMARY KEY  (NotiId)
);

CREATE TABLE Role (
    RoleId int  NOT NULL,
    Role nvarchar  NOT NULL,
    CONSTRAINT Role_pk PRIMARY KEY  (RoleId)
);

CREATE TABLE Skills (
    SkillId int  NOT NULL,
    Skill nvarchar  NOT NULL,
    Proficiency nvarchar  NOT NULL,
    User_UserId int  NOT NULL,
    CONSTRAINT Skills_pk PRIMARY KEY  (SkillId)
);

CREATE TABLE Squad (
    SquadId int  NOT NULL,
    Title nvarchar  NOT NULL,
    Description nvarchar  NOT NULL,
    CreatedAt date  NOT NULL,
    DeadLine date  NOT NULL,
    CONSTRAINT Squad_pk PRIMARY KEY  (SquadId)
);

CREATE TABLE SquadImage (
    SQImgId int  NOT NULL,
    SQimgURL nvarchar(max)  NOT NULL,
    Squad_SquadId int  NOT NULL,
    CONSTRAINT SquadImage_pk PRIMARY KEY  (SQImgId)
);

CREATE TABLE Status (
    StatusId int  NOT NULL,
    Status nvarchar  NOT NULL,
    Squad_SquadId int  NOT NULL,
    CONSTRAINT Status_pk PRIMARY KEY  (StatusId)
);

CREATE TABLE "User" (
    UserId int  NOT NULL,
    UserName nvarchar  NOT NULL,
    Nickname nvarchar  NOT NULL,
    Email nvarchar  NOT NULL,
    Password nvarchar  NOT NULL,
    Age int  NOT NULL,
    Address nvarchar(max)  NOT NULL,
    Phone int  NOT NULL,
    Role_RoleId int  NOT NULL,
    CONSTRAINT User_pk PRIMARY KEY  (UserId)
);

CREATE TABLE UserSquad (
    UserSquadId int  NOT NULL,
    Squad_SquadId int  NOT NULL,
    User_UserId int  NOT NULL,
    CONSTRAINT UserSquad_pk PRIMARY KEY  (UserSquadId)
);

CREATE TABLE Whisper (
    WhispId int  NOT NULL,
    WhisperContent nvarchar  NOT NULL,
    Squad_SquadId int  NOT NULL,
    User_UserId int  NOT NULL,
    WhisperTopic_WTopicId int  NOT NULL,
    WhisperType_WTypeId int  NOT NULL,
    CONSTRAINT Whisper_pk PRIMARY KEY  (WhispId)
);

CREATE TABLE WhisperTopic (
    WTopicId int  NOT NULL,
    Topic nvarchar  NOT NULL,
    CONSTRAINT WhisperTopic_pk PRIMARY KEY  (WTopicId)
);

CREATE TABLE WhisperType (
    WTypeId int  NOT NULL,
    Type nvarchar  NOT NULL,
    CONSTRAINT WhisperType_pk PRIMARY KEY  (WTypeId)
);
