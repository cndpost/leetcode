package com.example;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.ListView;
import javafx.scene.control.TextField;

public class MainController {

    @FXML
    private TextField inputField;

    @FXML
    private ListView<String> listView;

    private final ObservableList<String> items =
            FXCollections.observableArrayList();

    @FXML
    private void initialize() {
        listView.setItems(items);
    }

    @FXML
    private void onAddClicked() {
        String text = inputField.getText();
        if (text != null && !text.isBlank()) {
            items.add(text);
            inputField.clear();
        }
    }
}
