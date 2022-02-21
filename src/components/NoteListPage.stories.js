import React from "react";
import { action } from "@storybook/addon-actions";
import NoteListPage from "./NoteListPage";

export default {
    Title: "NoteListPage",
    Component: NoteListPage
};

//uuuhNotePlease
export const uuuhNotePlease = () => {
    return (<NoteListPage/>);
}