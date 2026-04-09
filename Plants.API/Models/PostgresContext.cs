using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Plants.API;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BatchParameter> BatchParameters { get; set; }

    public virtual DbSet<BatchRawMaterial> BatchRawMaterials { get; set; }

    public virtual DbSet<BatchStep> BatchSteps { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Deviation> Deviations { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<LabResult> LabResults { get; set; }

    public virtual DbSet<LabTest> LabTests { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductionBatch> ProductionBatches { get; set; }

    public virtual DbSet<RawMaterial> RawMaterials { get; set; }

    public virtual DbSet<RawMaterialBatch> RawMaterialBatches { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeComponent> RecipeComponents { get; set; }

    public virtual DbSet<StepParameter> StepParameters { get; set; }

    public virtual DbSet<TechMap> TechMaps { get; set; }

    public virtual DbSet<TechStep> TechSteps { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BatchParameter>(entity =>
        {
            entity.HasKey(e => e.IdActual).HasName("batch_parameters_pkey");

            entity.ToTable("batch_parameters");

            entity.Property(e => e.IdActual).HasColumnName("id_actual");
            entity.Property(e => e.ActualValue)
                .HasPrecision(15, 3)
                .HasColumnName("actual_value");
            entity.Property(e => e.IdExecution).HasColumnName("id_execution");
            entity.Property(e => e.IdParam).HasColumnName("id_param");
            entity.Property(e => e.RecordedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("recorded_at");

            entity.HasOne(d => d.IdExecutionNavigation).WithMany(p => p.BatchParameters)
                .HasForeignKey(d => d.IdExecution)
                .HasConstraintName("batch_parameters_id_execution_fkey");

            entity.HasOne(d => d.IdParamNavigation).WithMany(p => p.BatchParameters)
                .HasForeignKey(d => d.IdParam)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("batch_parameters_id_param_fkey");
        });

        modelBuilder.Entity<BatchRawMaterial>(entity =>
        {
            entity.HasKey(e => e.IdRecord).HasName("batch_raw_materials_pkey");

            entity.ToTable("batch_raw_materials");

            entity.Property(e => e.IdRecord).HasColumnName("id_record");
            entity.Property(e => e.IdProductionBatch).HasColumnName("id_production_batch");
            entity.Property(e => e.IdRawMaterialBatch).HasColumnName("id_raw_material_batch");
            entity.Property(e => e.Quantity)
                .HasPrecision(15, 3)
                .HasColumnName("quantity");

            entity.HasOne(d => d.IdProductionBatchNavigation).WithMany(p => p.BatchRawMaterials)
                .HasForeignKey(d => d.IdProductionBatch)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("batch_raw_materials_id_production_batch_fkey");

            entity.HasOne(d => d.IdRawMaterialBatchNavigation).WithMany(p => p.BatchRawMaterials)
                .HasForeignKey(d => d.IdRawMaterialBatch)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("batch_raw_materials_id_raw_material_batch_fkey");
        });

        modelBuilder.Entity<BatchStep>(entity =>
        {
            entity.HasKey(e => e.IdExecution).HasName("batch_steps_pkey");

            entity.ToTable("batch_steps");

            entity.Property(e => e.IdExecution).HasColumnName("id_execution");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.FinishedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("finished_at");
            entity.Property(e => e.FinishedBy).HasColumnName("finished_by");
            entity.Property(e => e.IdProductionBatch).HasColumnName("id_production_batch");
            entity.Property(e => e.IdStep).HasColumnName("id_step");
            entity.Property(e => e.StartedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("started_at");
            entity.Property(e => e.StartedBy).HasColumnName("started_by");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.HasOne(d => d.FinishedByNavigation).WithMany(p => p.BatchStepFinishedByNavigations)
                .HasForeignKey(d => d.FinishedBy)
                .HasConstraintName("batch_steps_finished_by_fkey");

            entity.HasOne(d => d.IdProductionBatchNavigation).WithMany(p => p.BatchSteps)
                .HasForeignKey(d => d.IdProductionBatch)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("batch_steps_id_production_batch_fkey");

            entity.HasOne(d => d.IdStepNavigation).WithMany(p => p.BatchSteps)
                .HasForeignKey(d => d.IdStep)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("batch_steps_id_step_fkey");

            entity.HasOne(d => d.StartedByNavigation).WithMany(p => p.BatchStepStartedByNavigations)
                .HasForeignKey(d => d.StartedBy)
                .HasConstraintName("batch_steps_started_by_fkey");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.IdDepartment).HasName("departments_pkey");

            entity.ToTable("departments");

            entity.Property(e => e.IdDepartment).HasColumnName("id_department");
            entity.Property(e => e.IdParentDepartment).HasColumnName("id_parent_department");
            entity.Property(e => e.NameDepartment)
                .HasMaxLength(200)
                .HasColumnName("name_department");

            entity.HasOne(d => d.IdParentDepartmentNavigation).WithMany(p => p.InverseIdParentDepartmentNavigation)
                .HasForeignKey(d => d.IdParentDepartment)
                .HasConstraintName("departments_id_parent_department_fkey");
        });

        modelBuilder.Entity<Deviation>(entity =>
        {
            entity.HasKey(e => e.IdDeviation).HasName("deviations_pkey");

            entity.ToTable("deviations");

            entity.Property(e => e.IdDeviation).HasColumnName("id_deviation");
            entity.Property(e => e.ActualValue)
                .HasPrecision(15, 3)
                .HasColumnName("actual_value");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpectedValue)
                .HasPrecision(15, 3)
                .HasColumnName("expected_value");
            entity.Property(e => e.IdProductionBatch).HasColumnName("id_production_batch");
            entity.Property(e => e.IdStep).HasColumnName("id_step");
            entity.Property(e => e.ParameterName)
                .HasMaxLength(100)
                .HasColumnName("parameter_name");
            entity.Property(e => e.ResolutionComment).HasColumnName("resolution_comment");
            entity.Property(e => e.ResolvedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("resolved_at");
            entity.Property(e => e.Severity)
                .HasMaxLength(20)
                .HasColumnName("severity");

            entity.HasOne(d => d.IdProductionBatchNavigation).WithMany(p => p.Deviations)
                .HasForeignKey(d => d.IdProductionBatch)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("deviations_id_production_batch_fkey");

            entity.HasOne(d => d.IdStepNavigation).WithMany(p => p.Deviations)
                .HasForeignKey(d => d.IdStep)
                .HasConstraintName("deviations_id_step_fkey");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.IdEquipment).HasName("equipment_pkey");

            entity.ToTable("equipment");

            entity.Property(e => e.IdEquipment).HasColumnName("id_equipment");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Исправно'::character varying")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.IdEvent).HasName("events_pkey");

            entity.ToTable("events");

            entity.Property(e => e.IdEvent).HasColumnName("id_event");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.EventType)
                .HasMaxLength(50)
                .HasColumnName("event_type");
            entity.Property(e => e.IdProductionBatch).HasColumnName("id_production_batch");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Message).HasColumnName("message");

            entity.HasOne(d => d.IdProductionBatchNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdProductionBatch)
                .HasConstraintName("events_id_production_batch_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("events_id_user_fkey");
        });

        modelBuilder.Entity<LabResult>(entity =>
        {
            entity.HasKey(e => e.IdResult).HasName("lab_results_pkey");

            entity.ToTable("lab_results");

            entity.Property(e => e.IdResult).HasColumnName("id_result");
            entity.Property(e => e.ActualValue)
                .HasPrecision(10, 3)
                .HasColumnName("actual_value");
            entity.Property(e => e.IdTest).HasColumnName("id_test");
            entity.Property(e => e.NormMax)
                .HasPrecision(10, 3)
                .HasColumnName("norm_max");
            entity.Property(e => e.NormMin)
                .HasPrecision(10, 3)
                .HasColumnName("norm_min");
            entity.Property(e => e.ParameterName)
                .HasMaxLength(100)
                .HasColumnName("parameter_name");
            entity.Property(e => e.Unit)
                .HasMaxLength(20)
                .HasColumnName("unit");

            entity.HasOne(d => d.IdTestNavigation).WithMany(p => p.LabResults)
                .HasForeignKey(d => d.IdTest)
                .HasConstraintName("lab_results_id_test_fkey");
        });

        modelBuilder.Entity<LabTest>(entity =>
        {
            entity.HasKey(e => e.IdTest).HasName("lab_tests_pkey");

            entity.ToTable("lab_tests");

            entity.HasIndex(e => e.TestNumber, "lab_tests_test_number_key").IsUnique();

            entity.Property(e => e.IdTest).HasColumnName("id_test");
            entity.Property(e => e.AssignedTo).HasColumnName("assigned_to");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Conclusion)
                .HasMaxLength(50)
                .HasColumnName("conclusion");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.FinishedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("finished_at");
            entity.Property(e => e.IdProductionBatch).HasColumnName("id_production_batch");
            entity.Property(e => e.IdRawMaterialBatch).HasColumnName("id_raw_material_batch");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Назначен'::character varying")
                .HasColumnName("status");
            entity.Property(e => e.TestNumber)
                .HasMaxLength(100)
                .HasColumnName("test_number");

            entity.HasOne(d => d.AssignedToNavigation).WithMany(p => p.LabTests)
                .HasForeignKey(d => d.AssignedTo)
                .HasConstraintName("lab_tests_assigned_to_fkey");

            entity.HasOne(d => d.IdProductionBatchNavigation).WithMany(p => p.LabTests)
                .HasForeignKey(d => d.IdProductionBatch)
                .HasConstraintName("lab_tests_id_production_batch_fkey");

            entity.HasOne(d => d.IdRawMaterialBatchNavigation).WithMany(p => p.LabTests)
                .HasForeignKey(d => d.IdRawMaterialBatch)
                .HasConstraintName("lab_tests_id_raw_material_batch_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("products_pkey");

            entity.ToTable("products");

            entity.HasIndex(e => e.Code, "products_code_key").IsUnique();

            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Form)
                .HasMaxLength(100)
                .HasColumnName("form");
            entity.Property(e => e.NameProduct)
                .HasMaxLength(200)
                .HasColumnName("name_product");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Активный'::character varying")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .HasColumnName("type");
        });

        modelBuilder.Entity<ProductionBatch>(entity =>
        {
            entity.HasKey(e => e.IdBatch).HasName("production_batches_pkey");

            entity.ToTable("production_batches");

            entity.HasIndex(e => e.BatchNumber, "production_batches_batch_number_key").IsUnique();

            entity.Property(e => e.IdBatch).HasColumnName("id_batch");
            entity.Property(e => e.ActualQuantity)
                .HasPrecision(15, 3)
                .HasColumnName("actual_quantity");
            entity.Property(e => e.BatchNumber)
                .HasMaxLength(100)
                .HasColumnName("batch_number");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.FinishedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("finished_at");
            entity.Property(e => e.IdEquipment).HasColumnName("id_equipment");
            entity.Property(e => e.IdMap).HasColumnName("id_map");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdRecipe).HasColumnName("id_recipe");
            entity.Property(e => e.PlannedQuantity)
                .HasPrecision(15, 3)
                .HasColumnName("planned_quantity");
            entity.Property(e => e.StartedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("started_at");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Создана'::character varying")
                .HasColumnName("status");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ProductionBatches)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("production_batches_created_by_fkey");

            entity.HasOne(d => d.IdEquipmentNavigation).WithMany(p => p.ProductionBatches)
                .HasForeignKey(d => d.IdEquipment)
                .HasConstraintName("production_batches_id_equipment_fkey");

            entity.HasOne(d => d.IdMapNavigation).WithMany(p => p.ProductionBatches)
                .HasForeignKey(d => d.IdMap)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("production_batches_id_map_fkey");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ProductionBatches)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("production_batches_id_product_fkey");

            entity.HasOne(d => d.IdRecipeNavigation).WithMany(p => p.ProductionBatches)
                .HasForeignKey(d => d.IdRecipe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("production_batches_id_recipe_fkey");
        });

        modelBuilder.Entity<RawMaterial>(entity =>
        {
            entity.HasKey(e => e.IdRawMaterial).HasName("raw_materials_pkey");

            entity.ToTable("raw_materials");

            entity.HasIndex(e => e.Code, "raw_materials_code_key").IsUnique();

            entity.Property(e => e.IdRawMaterial).HasColumnName("id_raw_material");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Unit)
                .HasMaxLength(20)
                .HasColumnName("unit");
        });

        modelBuilder.Entity<RawMaterialBatch>(entity =>
        {
            entity.HasKey(e => e.IdBatch).HasName("raw_material_batches_pkey");

            entity.ToTable("raw_material_batches");

            entity.HasIndex(e => e.BatchNumber, "raw_material_batches_batch_number_key").IsUnique();

            entity.Property(e => e.IdBatch).HasColumnName("id_batch");
            entity.Property(e => e.BatchNumber)
                .HasMaxLength(100)
                .HasColumnName("batch_number");
            entity.Property(e => e.IdRawMaterial).HasColumnName("id_raw_material");
            entity.Property(e => e.Quantity)
                .HasPrecision(15, 3)
                .HasColumnName("quantity");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Поступило'::character varying")
                .HasColumnName("status");

            entity.HasOne(d => d.IdRawMaterialNavigation).WithMany(p => p.RawMaterialBatches)
                .HasForeignKey(d => d.IdRawMaterial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("raw_material_batches_id_raw_material_fkey");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.IdRecipe).HasName("recipes_pkey");

            entity.ToTable("recipes");

            entity.HasIndex(e => new { e.IdProduct, e.VersionNumber }, "recipes_id_product_version_number_key").IsUnique();

            entity.Property(e => e.IdRecipe).HasColumnName("id_recipe");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Черновик'::character varying")
                .HasColumnName("status");
            entity.Property(e => e.VersionNumber).HasColumnName("version_number");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recipes_created_by_fkey");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recipes_id_product_fkey");
        });

        modelBuilder.Entity<RecipeComponent>(entity =>
        {
            entity.HasKey(e => e.IdRecord).HasName("recipe_components_pkey");

            entity.ToTable("recipe_components");

            entity.Property(e => e.IdRecord).HasColumnName("id_record");
            entity.Property(e => e.IdRawMaterial).HasColumnName("id_raw_material");
            entity.Property(e => e.IdRecipe).HasColumnName("id_recipe");
            entity.Property(e => e.LoadingOrder).HasColumnName("loading_order");
            entity.Property(e => e.Percentage)
                .HasPrecision(5, 2)
                .HasColumnName("percentage");

            entity.HasOne(d => d.IdRawMaterialNavigation).WithMany(p => p.RecipeComponents)
                .HasForeignKey(d => d.IdRawMaterial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recipe_components_id_raw_material_fkey");

            entity.HasOne(d => d.IdRecipeNavigation).WithMany(p => p.RecipeComponents)
                .HasForeignKey(d => d.IdRecipe)
                .HasConstraintName("recipe_components_id_recipe_fkey");
        });

        modelBuilder.Entity<StepParameter>(entity =>
        {
            entity.HasKey(e => e.IdParam).HasName("step_parameters_pkey");

            entity.ToTable("step_parameters");

            entity.Property(e => e.IdParam).HasColumnName("id_param");
            entity.Property(e => e.IdStep).HasColumnName("id_step");
            entity.Property(e => e.MaxValue)
                .HasPrecision(15, 3)
                .HasColumnName("max_value");
            entity.Property(e => e.MinValue)
                .HasPrecision(15, 3)
                .HasColumnName("min_value");
            entity.Property(e => e.NameParam)
                .HasMaxLength(100)
                .HasColumnName("name_param");
            entity.Property(e => e.TargetValue)
                .HasPrecision(15, 3)
                .HasColumnName("target_value");
            entity.Property(e => e.Unit)
                .HasMaxLength(20)
                .HasColumnName("unit");

            entity.HasOne(d => d.IdStepNavigation).WithMany(p => p.StepParameters)
                .HasForeignKey(d => d.IdStep)
                .HasConstraintName("step_parameters_id_step_fkey");
        });

        modelBuilder.Entity<TechMap>(entity =>
        {
            entity.HasKey(e => e.IdMap).HasName("tech_maps_pkey");

            entity.ToTable("tech_maps");

            entity.HasIndex(e => new { e.IdProduct, e.VersionNumber }, "tech_maps_id_product_version_number_key").IsUnique();

            entity.Property(e => e.IdMap).HasColumnName("id_map");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Черновик'::character varying")
                .HasColumnName("status");
            entity.Property(e => e.VersionNumber).HasColumnName("version_number");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TechMaps)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tech_maps_created_by_fkey");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.TechMaps)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tech_maps_id_product_fkey");
        });

        modelBuilder.Entity<TechStep>(entity =>
        {
            entity.HasKey(e => e.IdStep).HasName("tech_steps_pkey");

            entity.ToTable("tech_steps");

            entity.Property(e => e.IdStep).HasColumnName("id_step");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IdMap).HasColumnName("id_map");
            entity.Property(e => e.IsMandatory)
                .HasDefaultValue(true)
                .HasColumnName("is_mandatory");
            entity.Property(e => e.NameStep)
                .HasMaxLength(200)
                .HasColumnName("name_step");
            entity.Property(e => e.StepOrder).HasColumnName("step_order");

            entity.HasOne(d => d.IdMapNavigation).WithMany(p => p.TechSteps)
                .HasForeignKey(d => d.IdMap)
                .HasConstraintName("tech_steps_id_map_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Login, "users_login_key").IsUnique();

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.IdDepartment).HasColumnName("id_department");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(100)
                .HasColumnName("login");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .HasColumnName("role");
            entity.Property(e => e.SecondName)
                .HasMaxLength(100)
                .HasColumnName("second_name");

            entity.HasOne(d => d.IdDepartmentNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdDepartment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_id_department_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
