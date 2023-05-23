module com.example.zadanie4 {
    requires javafx.controls;
    requires javafx.fxml;
            
        requires org.controlsfx.controls;
            requires com.dlsc.formsfx;
                        
    opens com.example.zadanie4 to javafx.fxml;
    exports com.example.zadanie4;
}