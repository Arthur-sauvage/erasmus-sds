package com.example.application.data.repository;

import com.example.application.data.entity.Course;

import java.util.List;
import java.util.UUID;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

public interface CourseRepository extends JpaRepository<Course, UUID> {

    @Query("select c from Course c " +
    "where lower(c.name) like lower(concat('%', :searchTerm, '%'))") 
  List<Course> search(@Param("searchTerm") String searchTerm);

}
