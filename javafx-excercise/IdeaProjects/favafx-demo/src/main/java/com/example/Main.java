package com.example;



import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.StackPane;
import javafx.stage.Stage;
import javafx.fxml.FXMLLoader;

public class Main extends Application {

    @Override
    public void start(Stage stage)  throws Exception {
        FXMLLoader loader = new FXMLLoader(
                getClass().getResource("/com/example/main_view.fxml")
        );
        Button btn = new Button("Hello JavaFX");
        btn.setOnAction(e -> System.out.println("Clicked"));

        StackPane root = new StackPane(btn);
     //   Scene scene = new Scene(root, 400, 300);
        Scene scene = new Scene(loader.load(), 400, 300);
        stage.setTitle("JavaFX FXML Demo");
        stage.setScene(scene);
        stage.show();
    }

    public static void main(String[] args) {
        launch(args);
    }
}