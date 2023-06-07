namespace StudentsCoursesManager.Data.Common
{
    public abstract class BaseEntity<TPrimaryKey>
    {
        public abstract TPrimaryKey Id { get; set; }
    }
}
