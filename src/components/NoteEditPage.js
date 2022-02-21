import React, {useState} from "react";

export default function NoteEditPage(props){
    const {
        ids,
        text,
        onSave,
        onCancel,
        onDelete
     } = props;

     const [value, setValue] = useState(text);

    return (
        <div className="page">
        <h1>Edit Page</h1>
        <textarea value={value} onChange={(event) => setValue(event.target.value)} />
        <br></br>
        <button type="button" onClick={() => onSave(value)}>Save</button>
        
        <button type="button" onClick={() => onCancel()}>Cancel</button>
        
        <button type="button" onClick={() => onDelete(ids)}>Delete</button>
        </div>
    );
}