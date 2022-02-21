import React from "react";
import { action } from "@storybook/addon-actions";
import NoteListItem from "./NoteListItem";

export default {
    Title: "NoteListItem",
    Component: NoteListItem
};

//short test
export const ShortText = () => {
    return (<NoteListItem id="1" createAt={new Date()} text="This is a short note"/>);
}
//long text
export const LongText = () => {
    return (<NoteListItem id="1" createAt={new Date()} text="Prow scuttle parrel provost Sail ho shrouds spirits boom mizzenmast yardarm. Pinnace holystone mizzenmast quarter crow's nest nipperkin grog yardarm hempen halter furl. Swab barque interloper chantey doubloon starboard grog black jack gangway rutters. Deadlights jack lad schooner scallywag dance the hempen jig carouser broadside cable strike colors. Bring a spring upon her cable holystone blow the man down spanker Shiver me timbers to go on account lookout wherry doubloon chase. Belay yo-ho-ho keelhaul squiffy black spot yardarm spyglass sheet transom heave to. Trysail Sail ho Corsair red ensign hulk smartly boom jib rum gangway. Case shot Shiver me timbers gangplank crack Jennys tea cup ballast Blimey lee snow crow's nest rutters. Fluke jib scourge of the seven seas boatswain schooner gaff booty Jack Tar transom spirits."/>);
}
//markdown text
export const MarkDownText = () => {
    return (<NoteListItem id="1" createAt={new Date()} text="This _is_ some **markdown** text"/>);
}
const sixDaysAgo  = Date.now() - (6 * 24 * 60 * 60 * 1000)
const twoWeeksAgo = Date.now() - (14 * 24 * 60 * 60 * 1000)
//created less than 1 week ago
export const LessThanOneWeek = () => {
    const createAt = new Date(sixDaysAgo);
    return (<NoteListItem id="1" createAt={createAt} text="This is a short note"/>);
}
//created more than 1 week ago
export const MoreThanOneWeek = () => {
    const createAt = new Date(twoWeeksAgo);
    return (<NoteListItem id="1" createAt={createAt} text="This is a short note"/>);
}
//click action
export const ClickAction = () => {
    return (<NoteListItem id="1" createAt={new Date()}  onclick = {action("onClick")}  text="This is a short note"/>);
}
//empty state
export const EmptyText = () => {
    return (<NoteListItem 
        id="1" 
        text=""
        />);
}
//space state
export const SpacesOnly = () => {
    return (<NoteListItem 
        id="1" 
        text="     "
        />);
}
//error state
export const ErrorInOnClick = () => {
    const onClick = () => {
        throw new Error("simulated error");
    };
    return (<NoteListItem id="1" createAt={new Date()} onclick = {onClick} text="This is a short note"/>);
}
