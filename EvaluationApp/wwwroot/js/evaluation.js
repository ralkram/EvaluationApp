function createPostModel(isCompleted, evaluationId) {
    var retModel = {};
    retModel.id = evaluationId;
    retModel.criteriaData = [];
    retModel.isCompleted = isCompleted ? true : false;

    $(".grade-val").each(function (index) {
        var criteria = {};
        criteria.id = $(this).data("criteria");
        criteria.sectionId = $(this).data("section");
        criteria.gradeId = $(this).val();
        retModel.criteriaData.push(criteria);
    });

    return retModel;
}

function saveEvaluation(finalized, evaluationId, postUrl, redirectUrl) {
    var hulla = new hullabaloo();
    var evalObject = createPostModel(finalized, evaluationId);
    var retVal = $.ajax
        ({
            type: "POST",
            url: postUrl,
            // The key needs to match your method's input parameter (case-sensitive).
            data: JSON.stringify(evalObject),
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (response) {
            if (response.isError === false) {
                //show success with response.text
                hulla.send(response.text, "success");
                if (redirectUrl) {
                    location.href = redirectUrl;
                }

            }
            else {
                //error
                hulla.send(response.text, "danger");
            }
        }).fail(function (failResponse) {
            var displayMessage = "" + failResponse.statusCode + " Failed to process the request";
            hulla.send(displayMessage, "danger");

        });

    return retVal;
}

function finalizeEvaluation(evaluationId, postUrl, redirectUrl) {
    saveEvaluation(true, evaluationId, postUrl, redirectUrl);
}