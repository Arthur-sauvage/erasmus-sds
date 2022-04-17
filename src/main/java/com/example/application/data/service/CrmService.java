package com.example.application.data.service;

import com.example.application.data.entity.Course;
import com.example.application.data.repository.CourseRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service 
public class CrmService {

    private final CourseRepository courseRepository;

    public CrmService(CourseRepository courseRepository) { 
        this.courseRepository = courseRepository;
    }

    public List<Course> findAllCourses(String stringFilter) {
        if (stringFilter == null || stringFilter.isEmpty()) { 
            return courseRepository.findAll();
        } else {
            return courseRepository.search(stringFilter);
        }
    }

    public long countCourses() {
        return courseRepository.count();
    }

    public void deleteCourse(Course course) {
        courseRepository.delete(course);
    }

    public void saveCourse(Course course) {
        if (course == null) { 
            System.err.println("Course is null. Are you sure you have connected your form to the application?");
            return;
        }
        courseRepository.save(course);
    }
}