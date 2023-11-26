﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PortfolioServer.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231124193748_UpdateTeacherWork2")]
    partial class UpdateTeacherWork2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PortfolioShared.Models.Award", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly?>("DateAward")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NameOrganization")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Awards");
                });

            modelBuilder.Entity("PortfolioShared.Models.AwardStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly?>("DateAward")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("AwardStudent");
                });

            modelBuilder.Entity("PortfolioShared.Models.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Disciplines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "История России"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Основы российской государственности"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Иностранный язык"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Философия"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Безопасность жизнедеятельности"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Русский язык и культура речи"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Высшая математика"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Информатика"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Развитие информационного общества"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Основы алгоритмизации"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Основы программирования"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Программная инженерия"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Операционные системы"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Экономика"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Правоведение"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Социология"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Психология"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Технологии разработки программного продукта"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Интернет технологии"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Информационная безопасность"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Численные методы"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Исследование операций"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Дискретная математика"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Математика криптографии"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Математические методы принятия решений"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Математический инструментарий и модели оценки бизнеса"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Анализ данных"
                        },
                        new
                        {
                            Id = 28,
                            Name = "Базы данных"
                        },
                        new
                        {
                            Id = 29,
                            Name = "Управление жизненным циклом информационных систем"
                        },
                        new
                        {
                            Id = 30,
                            Name = "ИТ инфраструкту рапредприятия"
                        },
                        new
                        {
                            Id = 31,
                            Name = "Управление проектами"
                        },
                        new
                        {
                            Id = 32,
                            Name = "Физическая культура и спорт"
                        },
                        new
                        {
                            Id = 33,
                            Name = "Информационные системы и технологии в управленческой деятельности"
                        },
                        new
                        {
                            Id = 34,
                            Name = "Специальные главы высшей математики"
                        },
                        new
                        {
                            Id = 35,
                            Name = "Вычислительные системы, сети, телекоммуникации"
                        },
                        new
                        {
                            Id = 36,
                            Name = "Электронный бизнес"
                        },
                        new
                        {
                            Id = 37,
                            Name = "Корпоративные информационные системы"
                        },
                        new
                        {
                            Id = 38,
                            Name = "Теория риска и моделирование рисковых ситуаций"
                        },
                        new
                        {
                            Id = 39,
                            Name = "Прогнозирование социальноэкономических процессов"
                        },
                        new
                        {
                            Id = 40,
                            Name = "Основы искусственного интеллекта"
                        },
                        new
                        {
                            Id = 41,
                            Name = "Основы научных исследований"
                        },
                        new
                        {
                            Id = 42,
                            Name = "Научно-исследовательская работа"
                        },
                        new
                        {
                            Id = 43,
                            Name = "Моделирование бизнеспроцессов"
                        },
                        new
                        {
                            Id = 44,
                            Name = "Теория систем и системный анализ"
                        },
                        new
                        {
                            Id = 45,
                            Name = "Системы поддержки принятия решений"
                        },
                        new
                        {
                            Id = 46,
                            Name = "Стандатизация, сертификация и управление качеством программного обеспечения"
                        },
                        new
                        {
                            Id = 47,
                            Name = "Стандартизация и сертификация товаров и услуг"
                        },
                        new
                        {
                            Id = 48,
                            Name = "Физическая культура и спорт"
                        },
                        new
                        {
                            Id = 49,
                            Name = "Основы военной подготовки"
                        },
                        new
                        {
                            Id = 50,
                            Name = "Ознакомительная (учебная) практика"
                        },
                        new
                        {
                            Id = 51,
                            Name = "Технологическая (учебная) практика"
                        },
                        new
                        {
                            Id = 52,
                            Name = "Технологическая (производственная) практика"
                        },
                        new
                        {
                            Id = 53,
                            Name = "Преддипломная (производственная) практика"
                        },
                        new
                        {
                            Id = 54,
                            Name = "Подготовка к процедуре защиты и защита выпускной квалификационной работы"
                        });
                });

            modelBuilder.Entity("PortfolioShared.Models.DisciplineTeacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DisciplineId")
                        .HasColumnType("int");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("TeacherId");

                    b.ToTable("DisciplineTeacher");
                });

            modelBuilder.Entity("PortfolioShared.Models.Dissertation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("YearProtection")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Dissertations");
                });

            modelBuilder.Entity("PortfolioShared.Models.ProfessionalDevelopment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly?>("DateСompletion")
                        .HasColumnType("date");

                    b.Property<int?>("ListeningTime")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NameDocument")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NameOrganization")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NumberDocument")
                        .HasColumnType("longtext");

                    b.Property<string>("SeriaDocument")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("ProfessionalDevelopments");
                });

            modelBuilder.Entity("PortfolioShared.Models.Publication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CoAuthor")
                        .HasColumnType("longtext");

                    b.Property<string>("Form")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OutputData")
                        .HasColumnType("longtext");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Publications");
                });

            modelBuilder.Entity("PortfolioShared.Models.ScienceProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ScienceProjects");
                });

            modelBuilder.Entity("PortfolioShared.Models.ScienceProjectTeacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("BeginTimeWork")
                        .HasColumnType("date");

                    b.Property<bool>("Director")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateOnly>("EndTimeWork")
                        .HasColumnType("date");

                    b.Property<int>("ScienceProjectId")
                        .HasColumnType("int");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ScienceProjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("ScienceProjectTeacher");
                });

            modelBuilder.Entity("PortfolioShared.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("PortfolioShared.Models.UniversityTeacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Qualification")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("char(36)");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.Property<int>("YearGraduation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.HasIndex("UniversityId");

                    b.ToTable("UniversityTeacher");
                });

            modelBuilder.Entity("PortfolioShared.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateOnly?>("DateBirthday")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("MiddleName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("PortfolioShared.Models.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("BeginTimeWork")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("EndTimeWork")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Post")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("PortfolioShared.Models.Student", b =>
                {
                    b.HasBaseType("PortfolioShared.Models.User");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("PortfolioShared.Models.Teacher", b =>
                {
                    b.HasBaseType("PortfolioShared.Models.User");

                    b.Property<string>("AcademicDegree")
                        .HasColumnType("longtext");

                    b.Property<string>("AcademicTitle")
                        .HasColumnType("longtext");

                    b.Property<byte[]>("Image")
                        .HasColumnType("longblob");

                    b.Property<string>("Post")
                        .HasColumnType("longtext");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("PortfolioShared.Models.Award", b =>
                {
                    b.HasOne("PortfolioShared.Models.Teacher", "Teacher")
                        .WithMany("Awards")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("PortfolioShared.Models.AwardStudent", b =>
                {
                    b.HasOne("PortfolioShared.Models.Student", "Student")
                        .WithMany("AwardStudents")
                        .HasForeignKey("StudentId");

                    b.HasOne("PortfolioShared.Models.Teacher", "Teacher")
                        .WithMany("AwardStudents")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("PortfolioShared.Models.DisciplineTeacher", b =>
                {
                    b.HasOne("PortfolioShared.Models.Discipline", null)
                        .WithMany()
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortfolioShared.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PortfolioShared.Models.Dissertation", b =>
                {
                    b.HasOne("PortfolioShared.Models.Teacher", "Teacher")
                        .WithMany("Dissertations")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("PortfolioShared.Models.ProfessionalDevelopment", b =>
                {
                    b.HasOne("PortfolioShared.Models.Teacher", "Teacher")
                        .WithMany("ProfessionalDevelopments")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("PortfolioShared.Models.Publication", b =>
                {
                    b.HasOne("PortfolioShared.Models.Teacher", "Teacher")
                        .WithMany("Publications")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("PortfolioShared.Models.ScienceProjectTeacher", b =>
                {
                    b.HasOne("PortfolioShared.Models.ScienceProject", null)
                        .WithMany()
                        .HasForeignKey("ScienceProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortfolioShared.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PortfolioShared.Models.UniversityTeacher", b =>
                {
                    b.HasOne("PortfolioShared.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortfolioShared.Models.University", null)
                        .WithMany()
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PortfolioShared.Models.Work", b =>
                {
                    b.HasOne("PortfolioShared.Models.Teacher", "Teacher")
                        .WithMany("Works")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("PortfolioShared.Models.Student", b =>
                {
                    b.HasOne("PortfolioShared.Models.User", null)
                        .WithOne()
                        .HasForeignKey("PortfolioShared.Models.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PortfolioShared.Models.Teacher", b =>
                {
                    b.HasOne("PortfolioShared.Models.User", null)
                        .WithOne()
                        .HasForeignKey("PortfolioShared.Models.Teacher", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PortfolioShared.Models.Student", b =>
                {
                    b.Navigation("AwardStudents");
                });

            modelBuilder.Entity("PortfolioShared.Models.Teacher", b =>
                {
                    b.Navigation("AwardStudents");

                    b.Navigation("Awards");

                    b.Navigation("Dissertations");

                    b.Navigation("ProfessionalDevelopments");

                    b.Navigation("Publications");

                    b.Navigation("Works");
                });
#pragma warning restore 612, 618
        }
    }
}
