import React from "react";
import PropTypes from 'prop-types';

import ReactMarkdown from "react-markdown";
import formatDate from "../util/formatDate"

export default function NoteListItem(props) {
    const { id } = props;
    const { text } = props;
    const { createAt } = props;
    const { onclick } = props;
   //const [timesClicked, setTimesClicked] = useState(0);
  //const oneHourAgo = Date.now() - (8 * 24 * 60 * 60 * 1000)
     //const createAt = new Date(oneHourAgo);
    const handleListItemClick = (event) =>{
        event.preventDefault();
        if (onclick) {
            onclick(id)
        }
    }
    return(
     
                <div className="noteListItem" onClick={handleListItemClick}>
                   
                    <ReactMarkdown children={truncate(imBlanking(text))} />
                    <p> 
                        {formatDate(createAt)}
                        </p>
                        {/* <p>
                            I've Been Clicked {timesClicked} times
                        </p> */}
                    
                </div>
           
    );
}

NoteListItem.propTypes = {
    id: PropTypes.string.isRequired,
    text: PropTypes.string.isRequired,
    createAt: PropTypes.instanceOf(Date).isRequired,
    onClick: PropTypes.func
};
function truncate(str) {
    return str.length > 200 ? str.substring(0,197) + "..." : str;
}
function imBlanking(text) {
    let thisTisEmpty = text.trim(text)
    if (thisTisEmpty === "" || thisTisEmpty === " "){
        thisTisEmpty = "No Note Text"
    }
    return thisTisEmpty;
}
