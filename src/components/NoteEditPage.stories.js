import React from "react";
import { action } from "@storybook/addon-actions";
import NoteEditPage from "./NoteEditPage";

export default {
    Title: "NoteEditPage",
    Component: NoteEditPage
};

//randomText
export const randomText = () => {
    return (<NoteEditPage id="1" text="Snow Squall Incoming"/>);
}
//noText
export const noText = () => {
    return (<NoteEditPage/>);
}
//saveIt
export const saveIt = () => {
    return (<NoteEditPage  id="1"  onSave = {action("onSave")} text="Snow Squall Incoming"/>);
}
//cancelIt
export const cancelIt = () => {
    return (<NoteEditPage  id="1"  onCancel = {action("onCancel")} text="Snow Squall Incoming"/>);
}
//deleteIt
export const deleteIt = () => {
    return (<NoteEditPage  id="1"  onDelete = {action("onDelete")} text="Snow Squall Incoming"/>);
}