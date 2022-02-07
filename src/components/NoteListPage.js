import React from "react";
import PropTypes from 'prop-types';
import NoteListItem from "./NoteListItem";

export default function NoteListPage(props) {

    return(
        <div className="page">
            <h1>Note List</h1>
            <div className="noteList">
                <div className="noteListItem">
                <NoteListItem id = "123" text="Taking notes is  very important" dateTimeText='1/25/2020 5:00pm' onclick={handleListItemClick} />
                </div>
            </div>
        </div>
    );
     
}

NoteListPage.propTypes = {
    text: PropTypes.string.isRequired
};
function handleListItemClick(ids){
    alert(ids + " Clicked!" )
}