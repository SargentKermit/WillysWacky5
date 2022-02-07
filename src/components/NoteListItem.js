import React from "react";
import PropTypes from 'prop-types';

export default function NoteListItem(props) {
    const { id } = props;
    const { text } = props;
    const { dateTimeText } = props;
    const { onclick } = props;
   
   

    return(
     
                <div className="noteListItem" onClick={() => {onclick(id)}}>
                    <p>{text}</p>
                    <p>{dateTimeText}</p>
                    <p>{truncate(Text)}</p>
                </div>
           
    );
}

NoteListItem.propTypes = {
    id: PropTypes.string.isRequired,
    text: PropTypes.string.isRequired,
    dateTimeText: PropTypes.string.isRequired
};
function truncate(str) {
    return str.length > 200 ? str.substring(0,197) + "..." : str;
}
