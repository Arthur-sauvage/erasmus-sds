package com.example.application.views.list;

import com.example.application.data.entity.Course;
import com.vaadin.flow.component.ComponentEvent;
import com.vaadin.flow.component.ComponentEventListener;
import com.vaadin.flow.component.Key;
import com.vaadin.flow.component.button.Button;
import com.vaadin.flow.component.button.ButtonVariant;
import com.vaadin.flow.component.formlayout.FormLayout;
import com.vaadin.flow.component.orderedlayout.HorizontalLayout;
import com.vaadin.flow.component.textfield.TextField;
import com.vaadin.flow.data.binder.BeanValidationBinder;
import com.vaadin.flow.data.binder.Binder;
import com.vaadin.flow.data.binder.ValidationException;
import com.vaadin.flow.shared.Registration;

public class CourseForm extends FormLayout { 
  private Course course;
  TextField name = new TextField("name"); 
  TextField description = new TextField("description");

  Button save = new Button("Save");
  Button delete = new Button("Delete");
  Button close = new Button("Cancel");

  Binder<Course> binder = new BeanValidationBinder<>(Course.class);

  public CourseForm() {
    
    addClassName("course-form");
    binder.bindInstanceFields(this); 

    add(name, 
        description,
        createButtonsLayout());
  }


  private HorizontalLayout createButtonsLayout() {
    save.addThemeVariants(ButtonVariant.LUMO_PRIMARY); 
    delete.addThemeVariants(ButtonVariant.LUMO_ERROR);
    close.addThemeVariants(ButtonVariant.LUMO_TERTIARY);

    save.addClickShortcut(Key.ENTER); 
    close.addClickShortcut(Key.ESCAPE);

    save.addClickListener(event -> validateAndSave()); 
    delete.addClickListener(event -> fireEvent(new DeleteEvent(this, course))); 
    close.addClickListener(event -> fireEvent(new CloseEvent(this))); 

    binder.addStatusChangeListener(e -> save.setEnabled(binder.isValid())); 

    return new HorizontalLayout(save, delete, close); 
  }

  private void validateAndSave() {
    try {
      binder.writeBean(course); 
      fireEvent(new SaveEvent(this, course)); 
    } catch (ValidationException e) {
      e.printStackTrace();
    }
  }

  public void setCourse(Course course) {
    this.course = course; 
    binder.readBean(course); 
  }

  public static abstract class CourseFormEvent extends ComponentEvent<CourseForm> {
    private Course course;
  
    protected CourseFormEvent(CourseForm source, Course course) { 
      super(source, false);
      this.course = course;
    }
  
    public Course getCourse() {
      return course;
    }
  }
  
  public static class SaveEvent extends CourseFormEvent {
    SaveEvent(CourseForm source, Course course) {
      super(source, course);
    }
  }
  
  public static class DeleteEvent extends CourseFormEvent {
    DeleteEvent(CourseForm source, Course course) {
      super(source, course);
    }
  
  }
  
  public static class CloseEvent extends CourseFormEvent {
    CloseEvent(CourseForm source) {
      super(source, null);
    }
  }
  
  public <T extends ComponentEvent<?>> Registration addListener(Class<T> eventType,
      ComponentEventListener<T> listener) { 
    return getEventBus().addListener(eventType, listener);
  }
}