package com.example.application.views.list;

import com.example.application.data.entity.Course;
import com.example.application.data.service.CrmService;
import com.vaadin.flow.component.button.Button;
import com.vaadin.flow.component.grid.Grid;
import com.vaadin.flow.component.orderedlayout.HorizontalLayout;
import com.vaadin.flow.component.orderedlayout.VerticalLayout;
import com.vaadin.flow.component.textfield.TextField;
import com.vaadin.flow.data.value.ValueChangeMode;
import com.vaadin.flow.router.PageTitle;
import com.vaadin.flow.router.Route;

@Route(value = "")
@PageTitle("Courses | Erasmus SDS")
public class ListView extends VerticalLayout {
    Grid<Course> grid = new Grid<>(Course.class);
    TextField filterText = new TextField();
    CourseForm form;
    CrmService service;

    public ListView(CrmService service) {
        this.service = service;
        addClassName("list-view");
        setSizeFull();
        configureGrid();
        configureForm();

        add(getToolbar(), getContent());
        updateList();
        closeEditor(); 
    }

    private HorizontalLayout getContent() {
        HorizontalLayout content = new HorizontalLayout(grid, form);
        content.setFlexGrow(2, grid);
        content.setFlexGrow(1, form);
        content.addClassNames("content");
        content.setSizeFull();
        return content;
    }

    private void configureForm() {
        form = new CourseForm();
        form.setWidth("25em");
        form.addListener(CourseForm.SaveEvent.class, this::saveCourse); 
        form.addListener(CourseForm.DeleteEvent.class, this::deleteCourse); 
        form.addListener(CourseForm.CloseEvent.class, e -> closeEditor()); 
    }

    private void saveCourse(CourseForm.SaveEvent event) {
        service.saveCourse(event.getCourse());
        updateList();
        closeEditor();
    }

    private void deleteCourse(CourseForm.DeleteEvent event) {
        service.deleteCourse(event.getCourse());
        updateList();
        closeEditor();
    }

    private void configureGrid() {
        grid.addClassNames("course-grid");
        grid.setSizeFull();
        grid.setColumns("name", "description");
        grid.getColumns().forEach(col -> col.setAutoWidth(true));

        grid.asSingleSelect().addValueChangeListener(event ->
            editContact(event.getValue()));
    }

    private HorizontalLayout getToolbar() {
        filterText.setPlaceholder("Filter by name...");
        filterText.setClearButtonVisible(true);
        filterText.setValueChangeMode(ValueChangeMode.LAZY);
        filterText.addValueChangeListener(e -> updateList());

        Button addCourseButton = new Button("Add course");
        addCourseButton.addClickListener(click -> addCourse()); 

        HorizontalLayout toolbar = new HorizontalLayout(filterText, addCourseButton);
        toolbar.addClassName("toolbar");
        return toolbar;
    }

    public void editContact(Course course) { 
        if (course == null) {
            closeEditor();
        } else {
            form.setCourse(course);
            form.setVisible(true);
            addClassName("editing");
        }
    }

    private void closeEditor() {
        form.setCourse(null);
        form.setVisible(false);
        removeClassName("editing");
    }

    private void addCourse() { 
        grid.asSingleSelect().clear();
        editContact(new Course());
    }


    private void updateList() {
        grid.setItems(service.findAllCourses(filterText.getValue()));
    }
}